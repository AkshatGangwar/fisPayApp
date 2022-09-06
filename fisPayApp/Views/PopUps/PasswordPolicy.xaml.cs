using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using fisPayApp.Handlers;

namespace fisPayApp.Views.PopUps;

public partial class PasswordPolicy : Popup
{
    public PasswordPolicy()
    {
        InitializeComponent();
        var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        var pageWidth = mainDisplayInfo.Width / mainDisplayInfo.Density;
        col1.Width = ((int)pageWidth) - 60;
        frame1.WidthRequest = ((int)pageWidth) - 60;
    }

    void Button_Clicked(object sender, EventArgs e) => Close();
}