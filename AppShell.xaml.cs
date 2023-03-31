using Memorize.View;

namespace Memorize;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(RegistrationCollectionCardPage), typeof(RegistrationCollectionCardPage));
        Routing.RegisterRoute(nameof(LearningLevel1), typeof(LearningLevel1));
    }
}