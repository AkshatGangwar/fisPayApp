using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using fisPayApp.Interfaces;
using fisPayApp.Handlers;
using fisPayApp.Services;

namespace MauiApp1;

public partial class PdfReports : ContentPage
{
    readonly IPdfCreate pdfCreate = new PdfService();
    public PdfReports()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		string from = FromDate.Date.ToString("yyyy-MM-dd");
        string to = ToDate.Date.ToString("yyyy-MM-dd");
        GetPdf(from, to);
    }
    async void GetPdf(string from, string to)
    {
        Indicator.IsVisible=true;
        var response = await pdfCreate.getPdf(from,to);
        if (response != null)
        {
            Indicator.IsVisible = false;
        }
        else
        {
            Indicator.IsVisible = false;
            Validation.toastmsg("Error", "S", 18);
        }
    }
}