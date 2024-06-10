using DatingProgram.Models;

namespace DatingProgram.Services
{
    public interface IAccountService
    {
        Task<Account> GetAccountByIdAsync(int Id);
        Task CreateAccount(Account account);
        Task UpdateAccount(Account account, int Id);
        Task DeleteAccount(int Id);
    }
}