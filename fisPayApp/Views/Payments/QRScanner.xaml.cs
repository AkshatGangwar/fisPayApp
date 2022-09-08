using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using fisPayApp.Interfaces;
using fisPayApp.Services;
using ZXing.Net.Maui;

namespace fisPayApp.Views.Payments;

public partial class QRScanner : ContentPage
{
    private string id;
    readonly ILoginRepository loginRepository = new LoginService();
    public QRScanner()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(MobilePay), typeof(MobilePay));
    }
    private void CameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        if (IsBusy)
            return;

        IsBusy = true;
        try
        {
            Dispatcher.Dispatch(() =>
        {
            id = $"{e.Results[0].Value}";

        });
        }
        catch (Exception)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var toast = Toast.Make("Error", ToastDuration.Short, 18);
            _ = toast.Show(cancellationTokenSource.Token);
        }
        finally
        {
            Next(id);
        }
    }
    private async void Next(string id)
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            var response = await loginRepository.GetUserName(id);
            if (response != null)
            {
                string name;
                if (response.dataObject.data.storeName != null)
                {
                    name = response.dataObject.data.storeName;
                }
                else
                {
                    name = response.dataObject.data.userName;
                }
                await Shell.Current.GoToAsync($"{nameof(MobilePay)}?name={name}&userId={id}");
            }
            else
            {
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