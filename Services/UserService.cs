using DatingSite.Models;

namespace DatingSite.Services
{
    public class UserService
    {

        public int? Id { get; set; }
        public Account CurrentAccount { get; set; } = new();
        public Profile SelectedProfile {  get; set; }= new();

        public void CurrentUser(Account account)
        {
            Id = account.AccountId;
            CurrentAccount = account;
        }

        public void LogOf()
        {
            Id = null;
            CurrentAccount = new();
            SelectedProfile = new Profile();
        }

    }
}
