using ShoppingList.Context;
using ShoppingList.Helpers;
using ShoppingList.Repositories;
using ShoppingList.Views;

namespace ShoppingList;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        // Repositories
        string dbPath = FileAccessHelper.GetLocalFilePath("promise.db3");
        builder.Services.AddTransient<PromiseRepository>(s => ActivatorUtilities.CreateInstance<PromiseRepository>(s, dbPath));
        
        builder.Services.AddSingleton<IContextStore, ContextStore>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<PromisesPage>();
        builder.Services.AddTransient<PromisePage>();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        



        return builder.Build();
    }
    
    
}