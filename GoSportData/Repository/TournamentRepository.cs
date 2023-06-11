using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GoSportData.Repository
{
    public class TournamentRepository : ITournamentsRepository
    {
        private readonly GoDbContext _context;
        public TournamentRepository(GoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tournaments>> GetAll()
        {
            List<Tournaments> tournaments = await _context.Tournaments.Include(c => c.Gender).Include(c => c.Sport).ToListAsync();
            return tournaments;
        }
        public async Task<List<Tournaments>> GetAllOver(int IdUser)
        {
            List<Tournaments> tournaments = await _context.Tournaments.Where(c => c.IsOver == false).Where(c => c.CreatedBy!.Id == IdUser).Include(c => c.Gender).Include(c => c.Sport).ToListAsync();
            return tournaments;
        }
        public async Task<List<Tournaments>> GetAllByGender(int GenderId)
        {
            List<Tournaments> tournaments = await _context.Tournaments.Where(c => c.Gender!.Id == GenderId).Include(c => c.Gender).Include(c => c.Sport).Include(c => c.CreatedBy).ToListAsync();
            return tournaments;
        }
        public async Task<List<Tournaments>> GetAllBySport(int SportId)
        {
            List<Tournaments> tournaments = await _context.Tournaments.Where(c => c.Sport!.Id == SportId).Include(c => c.Gender).Include(c => c.Sport).Include(c => c.CreatedBy).ToListAsync();
            return tournaments;
        }
        public async Task<List<Tournaments>> GetAllByUser(int UserId)
        {
            List<Tournaments> tournaments = await _context.Tournaments.Where(c => c.CreatedBy!.Id == UserId).Include(c => c.Gender).Include(c => c.Sport).Include(c => c.CreatedBy).ToListAsync();
            return tournaments;
        }
        public async Task<List<Tournaments>> GetAllByWithoutUser(int UserId)
        {
            List<Tournaments> tournaments = await _context.Tournaments.Where(c => c.CreatedBy!.Id != UserId).Include(c => c.Gender).Include(c => c.Sport).Include(c => c.CreatedBy).ToListAsync();
            List<Registrations> registrations = await _context.Registrations.Where(c => c.User!.Id == UserId).ToListAsync();
            List<Tournaments> finaltournaments = new();
            for (int i = 0; i < tournaments.Count; i++) 
            {
                bool toAdd = true;
                foreach(Registrations registration in registrations)
                {
                    if (tournaments[i] == registration.Tournament)
                    {
                        toAdd = false;
                    }
                }
                if(toAdd)
                {
                    finaltournaments.Add(tournaments[i]);
                }
            }
            return finaltournaments;
        }
        public async Task<Tournaments?> Get(int id)
        {
            Tournaments? tournament = await _context.Tournaments.Include(c => c.Gender).Include(c => c.Sport).Include(c => c.CreatedBy).FirstOrDefaultAsync(c => c.Id == id);
            return tournament;
        }
        public async Task Create(Tournaments tournaments)
        {
            await _context.Tournaments.AddAsync(tournaments);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Tournaments tournaments)
        {
            _context.Tournaments.Update(tournaments);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Tournaments? tournament = await Get(id);
            if(tournament != null)
            {
                _context.Tournaments.Remove(tournament);
                await _context.SaveChangesAsync();
            }
        }
    }
}
