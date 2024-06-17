using DatingSite.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.Security.Principal;

namespace DatingSite.Components.Pages
{
    public partial class AccountPage
    {
        public Account CurrentAccount { get; set; } = new();

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
            if (userservice.Id is not null)
            {
                await AccountService.UpdateAccount(CurrentAccount, (int)userservice.Id);
                navigationManager.NavigateTo("/Profiles");
            }
            else
            {
                await AccountService.CreateAccount(CurrentAccount);
                navigationManager.NavigateTo("/");
            }
        }
    }
}
