using System.Diagnostics;
using ShoppingList.Context;
using ShoppingList.ViewModels;

namespace ShoppingList;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(IContextStore contextStore)
    {
        InitializeComponent();
        BindingContext = new SettingsViewModel(contextStore);
    }

    private async void HomeButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }
}