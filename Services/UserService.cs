using DatingSite.Models;
using Newtonsoft.Json.Bson;

namespace DatingSite.Services
{
    public class UserService
    {
        public int? Id { get; set; }
        public Account CurrentAccount { get; set; } = new();
        public Profile? Profile { get; set; } = new();

        public void CurrentUser(Account account)
        {
            Id = account.AccountId;
            CurrentAccount = account;
        }

        public void LogOf()
        {
            Id = null;
            CurrentAccount = new();
            Profile = new Profile();
        }
    }
}
