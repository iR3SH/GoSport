using GoSportData.Classes;

namespace GoSportData.IRepository
{
    public interface IGendersRepository
    {
        public Task<List<Genders>> GetAll();
        public Task<Genders?> Get(int id);
        public Task Create(Genders gender);
        public Task Update(Genders gender);
        public Task Delete(int id);
    }
}
