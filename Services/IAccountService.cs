using DatingSite.Models;

namespace DatingSite.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int Id);
        Task CreateAccount(Account account);
        Task UpdateAccount(Account account, int Id);
        Task DeleteAccount(int Id);
    }
}