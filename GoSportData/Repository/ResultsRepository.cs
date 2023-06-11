using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GoSportData.Repository
{
    public class ResultsRepository : IResultsRepository
    {
        private readonly GoDbContext _context;
        public ResultsRepository(GoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Results>> GetAll()
        {
            List<Results> results = await _context.Results.Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Gender).Include(c => c.Tournament!.Sport).ToListAsync();
            return results;
        }
        public async Task<List<Results>> GetAllByUser(int UserId)
        {
            List<Results> results = await _context.Results.Where(c => c.User!.Id == UserId).Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Gender).Include(c => c.Tournament!.Sport).ToListAsync();
            return results;
        }
        public async Task<List<Results>> GetAllByTournament(int TournamentId)
        {
            List<Results> results = await _context.Results.Where(c => c.Tournament!.Id == TournamentId).Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Gender).Include(c => c.Tournament!.Sport).ToListAsync();
            return results;
        }
        public async Task<Results?> Get(int id)
        {
            Results? result = await _context.Results.Where(c => c.Id == id).Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Gender).Include(c => c.Tournament!.Sport).FirstOrDefaultAsync();
            return result;
        }
        public async Task<Results?> Get(int UserId, int TournamentId)
        {
            Results? result = await _context.Results.Where(c => c.User!.Id == UserId).Where(c => c.Tournament!.Id == TournamentId).Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Gender).Include(c => c.Tournament!.Sport).FirstOrDefaultAsync();
            return result;
        }
        public async Task Create(Results result)
        {
            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Results result)
        {
            _context.Results.Update(result);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Results? result = await Get(id);
            if(result != null)
            {
                _context.Results.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
