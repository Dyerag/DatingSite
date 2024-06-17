using DatingSite.Models;
using DatingSite.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DatingSite.Components.Pages
{
    public partial class ProfilePage
    {
        [Parameter]
        public int? ProfileId { get; set; }
        public Profile CurrentProfile { get; set; } = new();

        protected override Task OnParametersSetAsync()
        {
            if (ProfileId == null)
            {
                CurrentProfile.ProfileId = UserService.CurrentAccount.AccountId;
                CurrentProfile.Birthdate = UserService.CurrentAccount.Birthdate;
            }
                return base.OnParametersSetAsync();
        }

        async Task HandleSubmit()
        {
            if (ProfileId is not null)
            {
                await ProfileService.UpdateProfile(CurrentProfile, (int)ProfileId);
            }
            else
            {
                await ProfileService.CreateProfile(CurrentProfile);
            }
            NavigationManager.NavigateTo("/Profiles");
        }
    }
}
