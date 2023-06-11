using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoSport.Controllers
{
    public class TurnamentsController : Controller
    {
        private readonly IGendersRepository _repoGender;
        private readonly ISportsRepository _repoSport;
        private readonly ITournamentsRepository _repoTournament;
        private readonly IUsersRepository _repoUser;
        private readonly IRegistrationsRepository _repoRegistration;
        private readonly IResultsRepository _repoResults;
        public TurnamentsController(IGendersRepository repoGender, ISportsRepository repoSport, ITournamentsRepository repoTournament, IUsersRepository repoUser, IRegistrationsRepository repoRegistration, IResultsRepository repoResults)
        {
            _repoGender = repoGender;
            _repoSport = repoSport;
            _repoTournament = repoTournament;
            _repoUser = repoUser;
            _repoRegistration = repoRegistration;
            _repoResults = repoResults;
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            List<Genders> genders = await _repoGender.GetAll();
            List<Sports> sports = await _repoSport.GetAll();

            TempData["Genders"] = genders;
            TempData["Sports"] = sports;
            return View();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string Title, DateTime Date, int MaxUsers, int GenderId, int SportId)
        {
            Genders? gender = await _repoGender.Get(GenderId);
            Sports? sport = await _repoSport.Get(SportId);
            if (User.Identity!.IsAuthenticated)
            {
                Users? user = await _repoUser.GetByEmail(User.FindFirstValue(ClaimTypes.Email)!.ToString());
                if (gender != null || sport != null)
                {
                    Tournaments tournaments = new()
                    {
                        Title = Title,
                        Date = Date,
                        MaxUsers = MaxUsers,
                        Gender = gender,
                        Sport = sport,
                        CreatedBy = user
                    };
                    await _repoTournament.Create(tournaments);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Tournaments? tournament = await _repoTournament.Get(id);
            List<Genders> genders = await _repoGender.GetAll();
            List<Sports> sports = await _repoSport.GetAll();

            TempData["Turnament"] = tournament;
            TempData["Genders"] = genders;
            TempData["Sports"] = sports;
            return View();
        }

        [HttpPost("Edit/{IdTurnament}")]
        public async Task<IActionResult> Edit(int IdTurnament, string Title, DateTime Date, int MaxUsers, int GenderId, int SportId)
        {
            Tournaments? tournament = await _repoTournament.Get(IdTurnament);
            Genders? gender = await _repoGender.Get(GenderId);
            Sports? sport = await _repoSport.Get(SportId);
            if (tournament != null)
            {
                tournament.Title = Title;
                tournament.Date = Date;
                tournament.MaxUsers = MaxUsers;
                tournament.Gender = gender;
                tournament.Sport = sport;

                await _repoTournament.Update(tournament);
                TempData["Success"] = "Votre tournoi a bien été mis à jour";
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> ViewDetails(int id)
        {
            Tournaments? tournament = await _repoTournament.Get(id);
            if (tournament != null)
            {
                TempData["Tournament"] = tournament;
            }
            return View();
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repoTournament.Delete(id);
            TempData["Success"] = "Votre tournois a bien été supprimé !";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet("Subscribe/{id}")]
        public async Task<IActionResult> Subscribe(int id)
        {
            Tournaments? tournament = await _repoTournament.Get(id);
            if (tournament != null)
            {
                Users? user = await _repoUser.GetByEmail(User.FindFirstValue(ClaimTypes.Email)!.ToString());
                if (user != null)
                {
                    Registrations newRegi = new()
                    {
                        Tournament = tournament,
                        User = user
                    };
                    await _repoRegistration.Create(newRegi);
                    TempData["Success"] = "Vous avez bien été inscrit !";
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet("Unsubscribe/{id}")]
        public async Task<IActionResult> Unsubscribe(int id)
        {
            Tournaments? tournament = await _repoTournament.Get(id);
            if (tournament != null)
            {
                Users? user = await _repoUser.GetByEmail(User.FindFirstValue(ClaimTypes.Email)!.ToString());
                if (user != null)
                {
                    Registrations? newRegi = await _repoRegistration.Get(user.Id, tournament.Id);
                    if (newRegi != null)
                    {
                        await _repoRegistration.Delete(newRegi.Id);
                        TempData["Success"] = "Vous avez bien été désinscrit du tournoi !";
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet("AddResults/{id}")]
        public async Task<IActionResult> AddResults(int id)
        {
            List<Registrations> registrations = await _repoRegistration.GetAllByTournament(id);
            List<Users> users = new();
            List<GoSportData.Classes.Results> results = await _repoResults.GetAllByTournament(id);
            foreach (Registrations registration in registrations)
            {
                GoSportData.Classes.Results? result = await _repoResults.Get(registration.User!.Id, registration.Tournament!.Id);
                if (result == null)
                {
                    users.Add(registration.User);
                }
            }
            ViewData["Users"] = users;
            ViewData["Turnament"] = registrations[0].Tournament;
            ViewData["Results"] = results;
            return View();
        }
        [HttpPost("AddResults/{id}")]
        public async Task<IActionResult> AddResult(int idTurnament, int idUser, string Score, int Position)
        {
            Tournaments? tournament = await _repoTournament.Get(idTurnament);
            if(tournament != null)
            {
                Users? user = await _repoUser.Get(idUser);
                if (user != null)
                {
                    GoSportData.Classes.Results result = new()
                    {
                        User = user,
                        Tournament = tournament,
                        Score = Score,
                        Position = Position
                    };
                    await _repoResults.Create(result);
                }
            }
            return RedirectToAction("AddResult", "Turnaments", idTurnament);
        }
        [HttpGet("DeleteResult/{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            GoSportData.Classes.Results? result = await _repoResults.Get(id);
            int idTurnament = 0;
            if (result != null)
            {
                idTurnament = result.Tournament!.Id;
                await _repoResults.Delete(result.Id);
            }
            return RedirectToAction("AddResult", "Turnaments", idTurnament);
        }
        [HttpGet("Finished")]
        public async Task<IActionResult> Finished()
        {
            Users? user = await _repoUser.GetByEmail(User.FindFirstValue(ClaimTypes.Email)!.ToString());
            Dictionary<Tournaments, int> tournamentscounted = new();
            if (user != null)
            {
                List<Tournaments> tournaments = await _repoTournament.GetAllOver(user.Id);
                foreach(Tournaments tournament in tournaments)
                {
                    int count = await _repoRegistration.GetRegistrationCount(tournament);
                    tournamentscounted.Add(tournament, count);
                }
                TempData["myTournaments"] = tournamentscounted;
            }
            return View();
        }
    }
}
