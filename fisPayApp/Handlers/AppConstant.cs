using fisPayApp.Controls;
using fisPayApp.Views.DashBoard;
using fisPayApp.Views.Person;
using fisPayApp.Views.Vendor;
using MauiApp1;

namespace fisPayApp.Handlers
{
    public class AppConstant
    {
        public async static Task AddFlyoutMenusDetails()
        {
            Shell.Current.FlyoutHeader = new FlyoutHeaderControl();

            var personDashboardInfo = Shell.Current.Items.Where(f => f.Route == nameof(PersonDashBoardPage)).FirstOrDefault();
            if (personDashboardInfo != null) Shell.Current.Items.Remove(personDashboardInfo);

            var vendorDashboardInfo = Shell.Current.Items.Where(f => f.Route == nameof(VendorDashBoardPage)).FirstOrDefault();
            if (vendorDashboardInfo != null) Shell.Current.Items.Remove(vendorDashboardInfo);


            if (App.UserDetails.userType == "1")
            {
                var flyoutItem = new FlyoutItem()
                {
                    //Title = "Dashboard Page",
                    Route = nameof(PersonDashBoardPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                            {
                                new ShellContent
                                {
                                    Icon = Icons.Dashboard,
                                    Title = "Dashboard",
                                    ContentTemplate = new DataTemplate(typeof(PersonDashBoardPage)),
                                },
                                new ShellContent
                                {
                                    Icon = Icons.Profile,
                                    Title = "Profile",
                                    ContentTemplate = new DataTemplate(typeof(PersonProfile)),
                                },
                                new ShellContent
                                {
                                    Icon = Icons.Help,
                                    Title = "24×7 Help & Support",
                                    ContentTemplate = new DataTemplate(typeof(HelpPage)),
                                },
                            }
                };
                if (!Shell.Current.Items.Contains(flyoutItem))
                {
                    Shell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(PersonDashBoardPage)}");
                }

            }

            if (App.UserDetails.userType == "2")
            {
                var flyoutItem = new FlyoutItem()
                {
                    //Title = "Dashboard Page",
                    Route = nameof(VendorDashBoardPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                                new ShellContent
                                {
                                    Icon = Icons.Dashboard,
                                    Title = "Dashboard",
                                    ContentTemplate = new DataTemplate(typeof(VendorDashBoardPage)),
                                },
                                new ShellContent
                                {
                                    Icon = Icons.Profile,
                                    Title = "Profile",
                                    ContentTemplate = new DataTemplate(typeof(PersonProfile)),
                                },
                                 new ShellContent
                                {
                                    Icon = Icons.Help,
                                    Title = "24×7 Help & Support",
                                    ContentTemplate = new DataTemplate(typeof(HelpPage)),
                                },
                   }
                };

                if (!Shell.Current.Items.Contains(flyoutItem))
                {
                    Shell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(VendorDashBoardPage)}");
                }
            }
        }

    }
}
