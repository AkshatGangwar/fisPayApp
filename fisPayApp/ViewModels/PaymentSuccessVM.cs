using CommunityToolkit.Mvvm.Input;
using fisPayApp.Handlers;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(Amount), "amount")]
    [QueryProperty(nameof(Username), "username")]
    public partial class PaymentSuccessVM: BaseVM
    {
        private string amount;
        public string Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        async void Home()
        {
            await AppConstant.AddFlyoutMenusDetails();
        }
    }
}
