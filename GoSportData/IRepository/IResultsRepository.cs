using GoSportData.Classes;

namespace GoSportData.IRepository
{
    public interface IResultsRepository
    {
        public Task<List<Results>> GetAll();
        public Task<List<Results>> GetAllByTournament(int TournamentId);
        public Task<List<Results>> GetAllByUser(int UserId);
        public Task<Results?> Get(int id);
        public Task<Results?> Get(int UserId, int TournamentId);
        public Task Create(Results results);
        public Task Update(Results results);
        public Task Delete(int id);
    }
}
