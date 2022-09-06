namespace fisPayApp.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
    public FlyoutHeaderControl()
    {
        InitializeComponent();

        if (App.UserDetails != null)
        {
            lblUserName.Text = App.UserDetails.name;
            qrdata.Value = App.UserDetails.userId;
        }
    }
}