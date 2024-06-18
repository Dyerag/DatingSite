using DatingSite.Models;
using System.Xml.XPath;

namespace DatingSite.Components.Pages
{
    public partial class DetailsPage
    {
        public bool Searching { get; set; } = true;
        public List<Profile> UserProfiles { get; set; } = new List<Profile>();

        protected override async Task OnParametersSetAsync()
        {
            await Task.Delay(1000);
            var allProfiles = await ProfileService.GetAllProfiles();
            foreach (var profile in allProfiles)
            {
                if (profile.ProfileId == UserService.CurrentAccount.AccountId)
                    UserService.Profile = profile;
            }
            Searching = false;
        }

        public void EditProfile(int id) => NavigationManager.NavigateTo($"/Detail/Edit Profile/{id}");

        public async Task DeleteProfile(int id)
        {
            if (UserService.Profile == await ProfileService.GetProfileById(id))
                UserService.Profile = null;

            await ProfileService.DeleteProfile(id);
        }

        public async Task UseProfile(int id)
        {
            UserService.Profile = await ProfileService.GetProfileById(id);
        }
    }
}
