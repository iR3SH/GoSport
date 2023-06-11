using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GoSportData.Repository
{
    public class RegistrationsRepository : IRegistrationsRepository
    {
        private readonly GoDbContext _context;
        public RegistrationsRepository(GoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Registrations>> GetAll()
        {
            List<Registrations> registrations = await _context.Registrations.Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Sport).ToListAsync();
            return registrations;
        }
        public async Task<List<Registrations>>GetAllByUser(int UserId)
        {
            List<Registrations> registrations = await _context.Registrations.Where(c => c.User!.Id == UserId).Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Sport).ToListAsync();
            return registrations;
        }
        public async Task<List<Registrations>> GetAllByTournament(int TournamentId)
        {
            List<Registrations> registrations = await _context.Registrations.Where(c => c.Tournament!.Id == TournamentId).Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Sport).ToListAsync();
            return registrations;
        }
        public async Task<Registrations?> Get(int id)
        {
            Registrations? registration = await _context.Registrations.Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Sport).FirstOrDefaultAsync(c => c.Id == id);
            return registration;
        }
        public async Task<Registrations?> Get(int idUser, int idTournament)
        {
            Registrations? registration = await _context.Registrations.Where(c => c.User!.Id == idUser).Where(c => c.Tournament!.Id == idTournament).Include(c => c.User).Include(c => c.Tournament).Include(c => c.Tournament!.Sport).FirstOrDefaultAsync();
            return registration;
        }
        public async Task<int> GetRegistrationCount(Tournaments tournament)
        {
            List<Registrations> registrations = await GetAllByTournament(tournament.Id);
            return registrations.Count();
        }
        public async Task Create(Registrations registration)
        {
            await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Registrations registration)
        {
            _context.Registrations.Update(registration);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Registrations? registration = await Get(id);
            if(registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
        }
    }
}
