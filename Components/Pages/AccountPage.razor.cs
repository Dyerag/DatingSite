using DatingSite.Models;
using Microsoft.AspNetCore.Components;

namespace DatingSite.Components.Pages
{
    public partial class AccountPage
    {
        [Parameter]
        public int Id { get; set; }

        public Account EditAccount { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            var account = await AccountService.GetAccountByIdAsync((int)Id);
            if (account != null)
            {
                EditAccount = account;
            }
        }
    }
}
