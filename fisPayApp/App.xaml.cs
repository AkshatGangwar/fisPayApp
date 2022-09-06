using fisPayApp.Models;

namespace fisPayApp;

public partial class App : Application
{
	public static UserInfo UserDetails;
    public static string Token;
    public static string FilePath;
    public App()
	{
		InitializeComponent();
        MainPage = new AppShell();
	}
}
