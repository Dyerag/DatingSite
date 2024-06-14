using DatingSite.Models;

namespace DatingSite.Components.Pages
{
    public partial class ProfilePage
    {
        public List<Profile> UserProfiles { get; set; }=new List<Profile>();

        protected override async Task OnParametersSetAsync()
        {
            UserProfiles=await 
        }
    }
}
