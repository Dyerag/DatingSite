using DatingSite.Models;
using System.Xml.XPath;

namespace DatingSite.Components.Pages
{
    public partial class DetailsPage
    {
        public string CityName { get; set; }
        public void EditProfile(int id) => NavigationManager.NavigateTo($"/Detail/Edit Profile/{id}");

        protected override async Task OnInitializedAsync()
        {
            var city = await CityService.GetCityById(UserService.CurrentAccount.Zipcode);
            CityName = city.CityName;
        }
    }
}
