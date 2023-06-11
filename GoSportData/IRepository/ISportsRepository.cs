using GoSportData.Classes;

namespace GoSportData.IRepository
{
    public interface ISportsRepository
    {
        public Task<List<Sports>> GetAll();
        public Task<Sports?> Get(int id);
        public Task Create(Sports sports);
        public Task Update (Sports sports);
        public Task Delete(int id);
    }
}
