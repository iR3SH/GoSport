using GoSportData.Classes;

namespace GoSportData.IRepository
{
    public interface ITournamentsRepository
    {
        public Task<List<Tournaments>> GetAll();
        public Task<List<Tournaments>> GetAllOver(int IdUser);
        public Task<List<Tournaments>> GetAllByGender(int GenderId);
        public Task<List<Tournaments>> GetAllBySport(int SportId);
        public Task<List<Tournaments>> GetAllByUser(int UserId);
        public Task<List<Tournaments>> GetAllByWithoutUser(int UserId);
        public Task<Tournaments?> Get(int id);
        public Task Create(Tournaments tournament);
        public Task Update(Tournaments tournament);
        public Task Delete(int id);
    }
}
