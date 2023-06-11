using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSportData.Repository
{
    public class SportsRepository : ISportsRepository
    {
        private readonly GoDbContext _context;
        public SportsRepository(GoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sports>> GetAll()
        {
            List<Sports> sports = await _context.Sports.ToListAsync();
            return sports;
        }

        public async Task<Sports?> Get(int id)
        {
            Sports? sport = await _context.Sports.FindAsync(id);
            return sport;
        }

        public async Task Create (Sports sport)
        {
            await _context.Sports.AddAsync(sport);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Sports sport)
        {
            _context.Sports.Update(sport);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Sports? sport = await Get(id);
            if(sport != null)
            {
                _context.Sports.Remove(sport);
                await _context.SaveChangesAsync();
            }
        }
    }
}
