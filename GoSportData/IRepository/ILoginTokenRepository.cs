using GoSportData.Classes;

namespace GoSportData.IRepository
{
    public interface ILoginTokenRepository
    {
        public Task<LoginTokens?> Get(int UserId);
        public Task Create(LoginTokens loginToken);
        public Task Update(LoginTokens loginToken);
        public Task Delete(int id);
    }
}
