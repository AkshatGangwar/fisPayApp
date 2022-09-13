using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Handlers;
using fisPayApp.Interfaces;
using fisPayApp.Models;
using fisPayApp.Services;
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
        readonly ILoginRepository loginRepository = new LoginService();
        [RelayCommand]
        async void Pay()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(UserId) && !string.IsNullOrWhiteSpace(Amount) && Amount != "0")
                {
                    Indicator = "True";
                    var response = await loginRepository.Pay(new AddWalletRequest
                    {
                        userId = UserId,
                        amount = Amount,
                        comment = Comment
                    });
                    if (response != null)
                    {
                        if (response.resultCode.statusCode == "200")
                        {
                            Indicator = "False";
                            Validation.toastmsg("Sucess!", "S", 18);
                            await Shell.Current.GoToAsync($"{nameof(PaymentSucess)}?amount={Amount}&username={Name}");
                        }
                        else
                        {
                            Indicator = "False";
                            Validation.toastmsg("Error", "S", 18);
                        }

                    }

                    else
                    {
                        Indicator = "False";
                        Validation.toastmsg("Error", "S", 18);
                    }
                }
                else
                {
                    Validation.toastmsg("Please Enter Proper Amount...", "S", 18);
                }
            }
            catch (Exception)
            {
                Indicator = "False";
                Validation.toastmsg("Error", "S", 18);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
