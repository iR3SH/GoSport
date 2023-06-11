using GoSportData.Classes;
using GoSportData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GoSportData.Repository
{
    public class LoginTokenRepository : ILoginTokenRepository
    {
        private readonly GoDbContext _context;
        public LoginTokenRepository(GoDbContext context)
        {
            _context = context;
        }

        public async Task<LoginTokens?> Get(int UserId)
        {
            LoginTokens? loginTokens = await _context.LoginTokens.Where(c => c.Users!.Id == UserId).Include(c => c.Users).FirstOrDefaultAsync();
            return loginTokens;
        }
        public async Task Create(LoginTokens loginToken)
        {
            await _context.LoginTokens.AddAsync(loginToken);
            await _context.SaveChangesAsync();
        }
        public async Task Update(LoginTokens loginToken)
        {
            _context.LoginTokens.Update(loginToken);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            LoginTokens? loginToken = await _context.LoginTokens.FindAsync(id);
            if(loginToken != null)
            {
                _context.LoginTokens.Remove(loginToken);
                await _context.SaveChangesAsync();
            }
        }
    }
}
