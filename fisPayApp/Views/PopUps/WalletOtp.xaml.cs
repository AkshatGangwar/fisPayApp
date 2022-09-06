using fisPayApp.Controls;
using fisPayApp.ViewModels;
using System.Threading;

namespace MauiApp1;

public partial class WalletOtp : BasePopUp
{
    private DateTime _startTime;
    private readonly int _duration = 30;
    private CancellationTokenSource _cancellationTokenSource = new();
    public List<Entry> myEntryList { get; set; }
    public WalletOtp()
    {
        InitializeComponent();
        var registratioOtpVM = new RegistratioOtpVM();
        BindingContext = registratioOtpVM;
        myEntryList = new List<Entry>();
        myEntryList.Add(entry1);
        myEntryList.Add(entry2);
        myEntryList.Add(entry3);
        myEntryList.Add(entry4);
        UpdateArc();
    }
    private void Entry_Focused(object sender, FocusEventArgs e)
    {
        box1.BorderColor = Colors.ForestGreen;
    }

    private void Entry_Focused_1(object sender, FocusEventArgs e)
    {
        box2.BorderColor = Colors.ForestGreen;
    }

    private void Entry_Focused_2(object sender, FocusEventArgs e)
    {
        box3.BorderColor = Colors.ForestGreen;
    }

    private void Entry_Focused_3(object sender, FocusEventArgs e)
    {
        box4.BorderColor = Colors.ForestGreen;
    }

    private void box1_Unfocused(object sender, FocusEventArgs e)
    {
        box1.BorderColor = Colors.Gray;
        box2.BorderColor = Colors.Gray;
        box3.BorderColor = Colors.Gray;
        box4.BorderColor = Colors.Gray;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {

        var entry = sender as Entry;
        if (entry.Text.Length == 1)
        {
            var list = myEntryList;
            var index = list.IndexOf(entry);
            var nextIndex = (index + 1) >= list.Count ? 0 : index + 1;
            var next = list.ElementAt(nextIndex);
            next?.Focus();
        }

    }
    private async void UpdateArc()
    {
        _startTime = DateTime.Now;
        _cancellationTokenSource = new CancellationTokenSource();
        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        {
            TimeSpan elapsedTime = DateTime.Now - _startTime;
            int secondsRemaining = (int)(_duration - elapsedTime.TotalSeconds);
            lblResend.Text = $"Resend in {secondsRemaining} sec";
            if (secondsRemaining == 0)
            {
                lblResend.Text = $"Resend";
                _cancellationTokenSource.Cancel();
                return;
            }
            await Task.Delay(500);
        }
    }

    private void lbl_TappedResend(object sender, EventArgs e)
    {
        if (lblResend.Text == "Resend")
        {
            UpdateArc();
        }

    }
}