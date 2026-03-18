using ExpenseManager.Services;
using Microsoft.Extensions.Logging;
using ExpenseManager.Pages;
using ExpenseManager.Storage;
using ExpenseManager.ViewModels;
using LecturerManager.Repository;


namespace ExpenseManager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Quicksand-Regular.ttf", "QuicksandRegular");
                fonts.AddFont("Quicksand-Bold.ttf", "QuicksandBold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<IStorageContext, InMemoryStorageContext>();
        builder.Services.AddSingleton<IRepository, Repository>();
        builder.Services.AddSingleton<IService, Service>();
        
        builder.Services.AddSingleton<IStorageService, StorageService>();
        
        builder.Services.AddTransient<WalletsPage>();
        builder.Services.AddTransient<WalletDetailsPage>();
        builder.Services.AddTransient<TransactionDetailsPage>();
        
        builder.Services.AddSingleton<WalletsViewModel>();
        builder.Services.AddTransient<WalletDetailsViewModel>();
        return builder.Build();
    }
}