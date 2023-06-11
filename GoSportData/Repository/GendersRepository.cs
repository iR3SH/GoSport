using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GoSportData.Repository
{
    public class GendersRepository : IGendersRepository
    {
        private readonly GoDbContext _context;
        public GendersRepository(GoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Genders>> GetAll()
        {
            List<Genders> genders = await _context.Gender.ToListAsync();
            return genders;
        }

        public async Task<Genders?> Get(int id)
        {
            Genders? gender = await _context.Gender.FindAsync(id);
            return gender;
        }
        public async Task Create(Genders gender)
        {
            await _context.Gender.AddAsync(gender);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Genders gender)
        {
            _context.Gender.Update(gender);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Genders? gender = await Get(id);
            if(gender != null)
            {
                _context.Gender.Remove(gender);
                await _context.SaveChangesAsync();
            }
        }
    }
}
