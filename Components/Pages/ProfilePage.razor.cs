using DatingSite.Models;

namespace DatingSite.Components.Pages
{
    public partial class ProfilePage
    {
        public List<Profile> UserProfiles { get; set; } = new List<Profile>();

        protected override async Task OnParametersSetAsync()
        {
            var allProfiles = await ProfileService.GetAllProfiles();
            foreach (var profile in allProfiles)
            {
                if(profile.ProfileId == UserService.CurrentAccount.AccountId)
                    UserProfiles.Add(profile);
            }
        }
    }
}
