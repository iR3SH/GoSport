using GoSportData.Classes;

namespace GoSportData.IRepository
{
    public interface IUsersRepository
    {
        public Task<List<Users>> GetAll();
        public Task<Users?> Get(int id);
        public Task<Users?> GetByEmail(string Email);
        public Task Create(Users user);
        public Task Update(Users user);
        public Task Delete(int id);
    }
}
