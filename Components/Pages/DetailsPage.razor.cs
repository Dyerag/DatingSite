using DatingSite.Models;
using DatingSite.Services;
using System.Xml.XPath;

namespace DatingSite.Components.Pages
{
    public partial class DetailsPage
    {
        public string CityName { get; set; }
        public void EditProfile(int id) => NavigationManager.NavigateTo($"/Details/Edit Profile/{id}");

        protected override async Task OnInitializedAsync()
        {
            var city = await CityService.GetCityById(UserService.CurrentAccount.Zipcode);

            if(city is not null)
            CityName = city.CityName;
        }

        public void EditAccount() => NavigationManager.NavigateTo("/Details/Edit Account");

        public async Task DeleteAccountAndProfile()
        {
            await ProfileService.DeleteProfile(UserService.Profile.ProfileId);
            await AccountService.DeleteAccount(UserService.CurrentAccount.AccountId);
            NavigationManager.NavigateTo("/");
        }
    }
}
