using DatingSite.Models;
using DatingSite.Services;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace DatingSite.Components.Pages
{
    public partial class Home
    {
        public Login Attempt { get; set; } = new();
        public bool WrongLogIn { get; set; } = false;
        void AccountCreation() => navigationManager.NavigateTo("/Create Account");

        async Task SignIn()
        {
            WrongLogIn = false;
            var accountList = await AccountService.GetAllAccounts();

            foreach (var account in accountList)
            {
                if (account.Username == Attempt.Username && account.Password == Attempt.Password && account.IsDeleted == false)
                {
                    Userservice.CurrentUser(account);
                    Userservice.Profile = await ProfileService.GetProfileById(account.AccountId);
                    navigationManager.NavigateTo("/Details");
                }
            }
            if (Userservice.Id == null)
                WrongLogIn = true;
        }
    }
}
