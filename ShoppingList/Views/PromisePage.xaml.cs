using ShoppingList.Context;
using ShoppingList.Models;
using ShoppingList.Repositories;
using ShoppingList.ViewModels;

namespace ShoppingList.Views;

public partial class PromisePage : ContentPage
{
    private readonly PromiseViewModel _promiseViewModel;
    public PromisePage(PromiseRepository promiseRepository, IContextStore contextStore)
    {
        InitializeComponent();
        _promiseViewModel = new PromiseViewModel(promiseRepository, contextStore);
        BindingContext = _promiseViewModel;
    }

    protected override void OnAppearing()
    {
        _promiseViewModel.Init();
        base.OnAppearing();
    }
}