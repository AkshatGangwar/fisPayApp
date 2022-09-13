using fisPayApp.Services;
using fisPayApp.Views.Updates;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fisPayApp.Interfaces;
using fisPayApp.Handlers;

namespace fisPayApp.ViewModels
{
    [QueryProperty(nameof(MobileNum), "mobileNum")]
    public partial class ForgotPwdVM : BaseVM
    {
        private string mobileNum;
        public string MobileNum
        {
            get => mobileNum;
            set
            {
                mobileNum = value;
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        private string indicator = "False";
        readonly ILoginRepository loginRepository = new LoginService();

        [RelayCommand]
        async void UpdatePassword()
        {
            if (!string.IsNullOrWhiteSpace(MobileNum))
            {
                Indicator = "True";
                var response = await loginRepository.UpdatePwdOtp(MobileNum);
                if (response != null)
                {
                    Indicator = "False";
                    await Shell.Current.GoToAsync($"{nameof(UpdatePwdOTP)}?mobileNum={MobileNum}&otp={response.dataObject.data.otp}&userId={response.dataObject.data.userId}");
                    Validation.toastmsg("OTP Sent Successfully!", "S", 18);
                }

                else
                {
                    Indicator = "False";
                    Validation.toastmsg("User Doesn't Exist with this Mobile Number!", "S", 18);
                }
            }
            else
            {
                Validation.toastmsg("Enter Mobile Number to Proceed...", "S", 18);
            }
        }
    }
}
