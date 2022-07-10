using System.Diagnostics;
using ShoppingList.Context;
using ShoppingList.ViewModels;

namespace ShoppingList.Views;

public partial class HomePage : ContentPage
{
    public HomePage(IContextStore contextStore)
    {
        InitializeComponent();
        BindingContext = new HomeViewModel(contextStore);
    }
    
    
    
    private async void SettingsButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("/settings");
    }
}