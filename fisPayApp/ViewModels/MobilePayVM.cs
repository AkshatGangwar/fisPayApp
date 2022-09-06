using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Views.Registration;
using MauiApp1;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(Name), "name")]
    [QueryProperty(nameof(UserId), "userId")]
    public partial class MobilePayVM : BaseVM
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string userId;
        public string UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertyChanged();
            }
        }
        [ObservableProperty]
        private string amount;
        [ObservableProperty]
        private string comment;
        [ObservableProperty]
        private string indicator = "False";
        [RelayCommand]
        async void Pay()
        {
            if (!string.IsNullOrWhiteSpace(UserId))
            {
                Indicator = "True";
                //var response = await loginRepository.RegistrationOtp(Mobile);
                await Task.Delay(1500);
                var response = "1234";
                if (response != null)
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Sucess!", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                    await Shell.Current.GoToAsync($"{nameof(PaymentSucess)}?amount={Amount}&username={Name}");
                }

                else
                {
                    Indicator = "False";
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    var toast = Toast.Make("Error", ToastDuration.Short, 18);
                    _ = toast.Show(cancellationTokenSource.Token);
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var toast = Toast.Make("Error", ToastDuration.Short, 18);
                _ = toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
