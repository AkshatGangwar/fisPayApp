﻿using fisPayApp.ViewModels;
using fisPayApp.Views;
using CommunityToolkit.Maui;
using ZXing.Net.Maui;

namespace fisPayApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
            .UseMauiCommunityToolkit()
        #region
			.ConfigureMauiHandlers(h =>
             {
                 h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
                 h.AddHandler(typeof(ZXing.Net.Maui.Controls.CameraView), typeof(CameraViewHandler));
                 h.AddHandler(typeof(ZXing.Net.Maui.Controls.BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
             });
        #endregion
        //Dependency Injection
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageVM>();
        builder.Services.AddTransient<ForgotPwd>();
        builder.Services.AddTransient<ForgotPwdVM>();
        builder.Services.AddTransient<PersonProfileVM>();
        return builder.Build();
    }
}