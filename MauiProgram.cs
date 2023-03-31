
using Memorize.Services;
using Memorize.View;
using Memorize.ViewModel;
using Microsoft.Extensions.Logging;

namespace Memorize;

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
            });

        builder.Services.AddSingleton<ICollectionCardService, CollectionCardService>();

        
        builder.Services.AddSingleton<CollectionCardPage>();
        builder.Services.AddTransient<RegistrationCollectionCardPage>();
        builder.Services.AddTransient<LearningLevel1>();


        builder.Services.AddSingleton<CollectionCardPageViewModel>();
        builder.Services.AddTransient<RegistrationCollectionCardViewModel>();
        builder.Services.AddTransient<LearningLevel1ViewModel>();
        
        return builder.Build();
    }
}