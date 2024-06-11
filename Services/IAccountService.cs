using DatingSite.Models;

namespace DatingSite.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int Id);
        Task CreateAccount(Account account);
        Task UpdateAccount(Account account, int Id);
        Task DeleteAccount(int Id);
    }
}