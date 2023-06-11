using GoSport.Models;
using GoSportData.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using GoSportData.IRepository;

namespace GoSport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersRepository _repoUser;
        private readonly ILoginTokenRepository _repoToken;
        private readonly ITournamentsRepository _repoTournaments;
        private readonly IRegistrationsRepository _repoRegistration;
        private readonly IResultsRepository _repoResults;

        public HomeController(ILogger<HomeController> logger, IUsersRepository repoUser, ILoginTokenRepository repoToken, ITournamentsRepository repoTournaments, IRegistrationsRepository repoRegistration, IResultsRepository repoResults)
        {
            _logger = logger;
            _repoUser = repoUser;
            _repoToken = repoToken;
            _repoTournaments = repoTournaments;
            _repoRegistration = repoRegistration;
            _repoResults = repoResults;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity!.IsAuthenticated) 
            {
                Users? user = await _repoUser.GetByEmail(User.FindFirstValue(ClaimTypes.Email)!.ToString());
                if (user != null)
                {
                    List<Tournaments> myTournaments = await _repoTournaments.GetAllByUser(user.Id);
                    Dictionary<Tournaments, int> myTournamentsCount = new();

                    List<Registrations> mySubscriptions = await _repoRegistration.GetAllByUser(user.Id);
                    Dictionary<Registrations, int> myRegistrations = new();

                    foreach(Tournaments tournament in myTournaments)
                    {
                        int count = await _repoRegistration.GetRegistrationCount(tournament);
                        myTournamentsCount.Add(tournament, count);
                    }
                    foreach(Registrations registrations in mySubscriptions)
                    {
                        Tournaments tournament = registrations.Tournament!;
                        int count = await _repoRegistration.GetRegistrationCount(tournament);
                        myRegistrations.Add(registrations, count);
                    }
                    TempData["myTournaments"] = myTournamentsCount;
                    TempData["mySubscriptions"] = myRegistrations;
                }
            }
            return View();
        }
        [HttpGet("Turnaments")]
        public async Task<IActionResult> Turnaments()
        {
            Users? user = await _repoUser.GetByEmail(User.FindFirstValue(ClaimTypes.Email)!.ToString());
            if (user != null)
            {
                List<Tournaments> tournaments = await _repoTournaments.GetAllByWithoutUser(user.Id);
                Dictionary<Tournaments, int> Turnaments = new();
                foreach (Tournaments tournament in tournaments)
                {
                    int registrations = await _repoRegistration.GetRegistrationCount(tournament);
                    Turnaments.Add(tournament, registrations);
                }
                TempData["Turnaments"] = Turnaments;
            }
            return View();
        }

        [HttpGet("Results/{id}")]
        public async Task<IActionResult> Results(int id)
        {
            List<GoSportData.Classes.Results> results = await _repoResults.GetAllByTournament(id);
            if(results.Count > 0)
            {
                Dictionary<GoSportData.Classes.Results, int> resultCounted = new();
                foreach (GoSportData.Classes.Results result in results)
                {
                    int count = await _repoRegistration.GetRegistrationCount(result.Tournament!);
                    resultCounted.Add(result, count);
                }
                TempData["Results"] = resultCounted;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}