namespace DatingSite.Components.Pages
{
    public partial class Home
    {
        void AccountCreation() => navigationManager.NavigateTo("/Create Account");

        void SignIn() => navigationManager.NavigateTo("/Main");
    }
}
