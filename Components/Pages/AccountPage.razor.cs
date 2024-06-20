using DatingSite.Models;
using DatingSite.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.Security.Principal;

namespace DatingSite.Components.Pages
{
    public partial class AccountPage
    {
        public Account CurrentAccount { get; set; } = new();
        public bool UsernameTaken { get; set; } = false;
        public bool CityInDatabase { get; set; } = true;

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
            // Resets the bools
            UsernameTaken = false;
            CityInDatabase = true;

            // Checks the database for, if the zipcode the user input is in there
            if (!ZipcodeCheck(await CityService.GetAllCities()))
                CityInDatabase = false;

            // Checks the username of existing accounts for if the inputtet username is taken
            if (UsernameCheck(await AccountService.GetAllAccounts()))
                UsernameTaken = true;

            // if both checks are passed with nothing wrong. the account can be saved
            if (CityInDatabase == true && UsernameTaken == false)
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
                    await AccountService.CreateAccount(CurrentAccount);
                    userservice.SetCurrentUser(CurrentAccount);

                    navigationManager.NavigateTo("/Create Profile");
                }
            }
        }

        /// <summary>
        /// Verifies that the user inputtet zipcode, exists in the database
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        private bool ZipcodeCheck(List<City> cities)
        {
            // List for the zipcodes
            List<int> zipcodeList = new();

            foreach (var city in cities)
                zipcodeList.Add(city.Zipcode);

            return zipcodeList.Contains(CurrentAccount.Zipcode);
        }

        /// <summary>
        /// Verifies that a non-deleted account hasn't already claimed the username
        /// </summary>
        /// <returns></returns>
        private bool UsernameCheck(List<Account> existingAccounts)
        {
            //goes through every accounts username
            foreach (var account in existingAccounts)
            {
                // compares the username of the new account to the existing non-deleted accounts
                // If the username is taken, return true
                if (account.Username == CurrentAccount.Username && account.IsDeleted == false && account.AccountId != CurrentAccount.AccountId)
                {
                    return true;
                }
            }
            // If the username is not taken, return false
            return false;
        }
    }
}