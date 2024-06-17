using DatingSite.Models;
using System.Xml.XPath;

namespace DatingSite.Components.Pages
{
    public partial class ProfileSelectionPage
    {
        public bool Searching { get; set; } = true;
        public List<Profile> UserProfiles { get; set; } = new List<Profile>();

        protected override async Task OnParametersSetAsync()
        {
            await Task.Delay(2000);
            var allProfiles = await ProfileService.GetAllProfiles();
            foreach (var profile in allProfiles)
            {
                if (profile.ProfileId == UserService.CurrentAccount.AccountId)
                    UserProfiles.Add(profile);
            }
            Searching = false;
        }

        public void NewProfile() => NavigationManager.NavigateTo("/Profiles/Create Profile");
    }
}
