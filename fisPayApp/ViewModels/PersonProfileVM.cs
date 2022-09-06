using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;
using fisPayApp.Views;

namespace fisPayApp.ViewModels
{
    public partial class PersonProfileVM: BaseVM
    {
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        public async void UpdatePersonProfile()
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email))
            {
                Indicator = "True";
                var response = await loginRepository.UpdatePersonProfile(new PersonProfileData
                {
                    name = Name,
                    userId = App.UserDetails.userId,
                    email = Email,
                });
                if (response.resultCode.statusCode == "200")
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Success!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
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
