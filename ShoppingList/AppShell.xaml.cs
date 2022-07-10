using ShoppingList.Views;

namespace ShoppingList;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("settings", typeof(SettingsPage));
        Routing.RegisterRoute("promise", typeof(PromisePage));
    }
}