using GoSportData.Classes;
using GoSportData.IRepository;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace GoSport.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository _repoUser;
        private readonly ILoginTokenRepository _repoToken;
        public LoginController(IUsersRepository repoUser, ILoginTokenRepository repoToken)
        {
            _repoUser = repoUser;
            _repoToken = repoToken;
        }
        // GET: LoginController
        [HttpGet("login")]
        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Email, string Password, bool RememberMe)
        {
            Users? user = await _repoUser.GetByEmail(Email);
            if(user == null)
            {
                return RedirectToAction("Index");
            }
            if(BC.Verify(Password, user.Password))
            {
                LoginTokens? loginToken = await _repoToken.Get(user.Id);
                LoginTokens? existing = null;
                if(loginToken == null)
                {
                    loginToken = new();
                }
                else
                {
                    existing = loginToken;
                    if(loginToken.Expirations > DateTime.Now)
                    {
                        await _repoToken.Delete(loginToken.Id);
                        loginToken = new();
                    }
                }
                if (RememberMe)
                {
                    if (string.IsNullOrEmpty(loginToken.Token))
                    {
                        loginToken.Token = BC.HashPassword(user.Email + user.FirstName + user.Id);
                    }
                    if (loginToken.Users == null)
                    {
                        loginToken.Users = user;
                    }
                    if (loginToken.Expirations == null)
                    {
                        loginToken.Expirations = DateTime.Now.AddMonths(1);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(loginToken.Token))
                    {
                        loginToken.Token = BC.HashPassword(user.Email + user.FirstName + user.Id);
                    }
                    if (loginToken.Users == null)
                    {
                        loginToken.Users = user;
                    }
                    if (loginToken.Expirations == null)
                    {
                        loginToken.Expirations = DateTime.Now.AddMinutes(15);
                    }
                }
                if (existing == null)
                {
                    await _repoToken.Create(loginToken);
                }
                else
                {
                    await _repoToken.Update(loginToken);
                }

                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Email, user!.Email!),
                    new Claim(ClaimTypes.Authentication, loginToken.Token)
                };

                ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new(identity);
                AuthenticationProperties authenticationProperties = new() { IsPersistent = RememberMe };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string Email, string Password, string FirstName, string LastName, DateTime Birthdate)
        {
            Users users = new()
            {
                Email = Email,
                Password = BC.HashPassword(Password),
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = Birthdate
            };
            await _repoUser.Create(users);
            return RedirectToAction("Index");
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
