using System.Diagnostics;
using ShoppingList.Context;
using ShoppingList.ViewModels;

namespace ShoppingList.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(IContextStore contextStore)
    {
        InitializeComponent();
        BindingContext = new SettingsViewModel(contextStore);
    }
}