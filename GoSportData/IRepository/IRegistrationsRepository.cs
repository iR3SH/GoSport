using GoSportData.Classes;

namespace GoSportData.IRepository
{
    public interface IRegistrationsRepository
    {
        public Task<List<Registrations>> GetAll();
        public Task<List<Registrations>> GetAllByUser(int UserId);
        public Task<List<Registrations>> GetAllByTournament(int TournamentId);
        public Task<Registrations?> Get(int id);
        public Task<Registrations?> Get(int idUser, int idTournament);
        public Task<int> GetRegistrationCount(Tournaments tournament);
        public Task Create(Registrations registrations);
        public Task Update(Registrations registrations);
        public Task Delete(int id);
    }
}
