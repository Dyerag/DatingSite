using DatingSite.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Principal;

namespace DatingSite.Components.Pages
{
    public partial class AccountPage
    {
        [Parameter]
        public int? Id { get; set; }
        public Account CurrentAccount { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            if (Id is not null)
            {
                var account = await AccountService.GetAccountByIdAsync((int)Id);
                if (account != null)
                {
                    CurrentAccount = account;
                }
            }
            
        }
        public async Task AddAccount()
        {
            await AccountService.CreateAccount(CurrentAccount);
        }
    }
}
