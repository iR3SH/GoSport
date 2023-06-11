using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GoSportData.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly GoDbContext _context;

        public UsersRepository(GoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAll()
        {
            List<Users> users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<Users?> Get(int id)
        {
            Users? user = await _context.Users.FindAsync(id);
            return user;
        }
        public async Task<Users?> GetByEmail(string Email)
        {
            Users? user = await _context.Users.Where(c => c.Email == Email).FirstOrDefaultAsync();
            return user;
        }
        public async Task Create(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Users? user = await Get(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
