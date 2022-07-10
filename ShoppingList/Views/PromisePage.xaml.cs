using ShoppingList.Context;
using ShoppingList.Models;
using ShoppingList.Repositories;
using ShoppingList.ViewModels;

namespace ShoppingList.Views;

public partial class PromisePage : ContentPage
{
    public PromisePage(PromiseRepository promiseRepository, IContextStore contextStore)
    {
        InitializeComponent();
        BindingContext = new PromiseViewModel(promiseRepository, contextStore);
    }
}