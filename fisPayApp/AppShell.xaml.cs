using fisPayApp.ViewModels;
namespace fisPayApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new AppShellVM();
    }
}
