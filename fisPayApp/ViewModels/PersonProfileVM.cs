using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Handlers;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;

namespace fisPayApp.ViewModels
{
    public partial class PersonProfileVM: BaseVM
    {
        [ObservableProperty]
        private string username= App.UserDetails.name;
        [ObservableProperty]
        private string useremail = App.UserDetails.emailId;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        public async void UpdatePersonProfile()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Useremail))
            {
                Indicator = "True";
                var response = await loginRepository.UpdatePersonProfile(new UpdateUserProfile
                {
                    Name = Username,
                    Id = App.UserDetails.userId,
                    Email = Useremail,
                });
                if (response!=null)
                {
                    if (response.resultCode.statusCode == "200")
                    {
                        Indicator = "False";
                        App.UserDetails.name = Username;
                        App.UserDetails.emailId = Useremail;
                        await AppConstant.AddFlyoutMenusDetails();
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Success!", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
                    }
                    else
                    {
                        Indicator = "False";
                        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                        var toast = Toast.Make("Error!", ToastDuration.Short, 18);
                        _ = toast.Show(cancellationTokenSource.Token);
                    }
                }
                else
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Error!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Enter Name/Email to Proceed...", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
