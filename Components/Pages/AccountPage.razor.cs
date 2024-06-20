using DatingSite.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.Security.Principal;

namespace DatingSite.Components.Pages
{
    public partial class AccountPage
    {
        public Account CurrentAccount { get; set; } = new();
        public bool UsernameTaken = false;

        protected override async Task OnParametersSetAsync()
        {
            if (userservice.Id is not null)
            {
                var account = await AccountService.GetAccountById((int)userservice.Id);
                if (account != null)
                {
                    CurrentAccount = account;

                }
            }
        }

        async Task HandleSubmit()
        {
            // If this is an existing account thats being edited
            if (userservice.Id is not null)
            {

                await AccountService.UpdateAccount(CurrentAccount, (int)userservice.Id);
                navigationManager.NavigateTo("/Details");
            }
            // If this is a new account
            else
            {
                //grabs every account in the database to compare usernames
                var existingAccounts = await AccountService.GetAllAccounts();
                //to keep track of how many accounts have been checked
                int accountsChecked = 0;

                //goes throug every accounts username
                foreach (var account in existingAccounts)
                {
                    accountsChecked++;
                    UsernameTaken = false;
                    // compares the usernames of the new account to the existing accounts
                    // If the username is taken, notify the user that they can't use it
                    if (account.Username == CurrentAccount.Username && account.IsDeleted == false)
                    {
                        UsernameTaken = true;
                    }
                    // If the username isn't taken, and the program has compared every account. Add the new account
                    else if (accountsChecked >= existingAccounts.Count)
                    {
                        await AccountService.CreateAccount(CurrentAccount);
                        userservice.SetCurrentUser(CurrentAccount);

                        navigationManager.NavigateTo("/Create Profile");
                    }

                }
            }
        }
    }
}
