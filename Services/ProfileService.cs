using DatingSite.Data;
using DatingSite.Models;

namespace DatingSite.Services
{
    public class ProfileService : IProfileServices
    {
        private readonly DatingContext _context;
        public ProfileService(DatingContext context)
        {
            _context = context;
        }

        public async Task CreateProfile(Profile profile)
        {
            _context.profiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfile(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                account.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Account> GetAccountById(int Id)
        {
            var account = await _context.Accounts.FindAsync(Id);
            return account;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            var result = await _context.Accounts.ToListAsync();
            return result;
        }

        public async Task UpdateAccount(Account account, int id)
        {
            var dbAccount = await _context.Accounts.FindAsync(id);
            if (dbAccount != null)
            {
                dbAccount.Firstname = account.Firstname;
                dbAccount.Lastname = account.Lastname;
                dbAccount.Email = account.Email;
                dbAccount.Password = account.Password;
                dbAccount.Birthdate = account.Birthdate;
                dbAccount.Zipcode = account.Zipcode;
                dbAccount.Username = account.Username;

                await _context.SaveChangesAsync();
            }
        }
    }
}
