namespace fisPayApp.Views.Person;

public partial class PersonProfile : ContentPage
{
    
    public PersonProfile()
    {
        InitializeComponent();
        Name.Text = App.UserDetails.name;
        Mobile.Text = App.UserDetails.mobile;
        Email.Text = App.UserDetails.emailId;
        Routing.RegisterRoute(nameof(UpdatePersonProfile), typeof(UpdatePersonProfile));
    }
}