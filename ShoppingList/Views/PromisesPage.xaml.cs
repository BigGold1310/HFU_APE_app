using ShoppingList.Context;
using ShoppingList.Repositories;
using ShoppingList.ViewModels;

namespace ShoppingList.Views;

public partial class PromisesPage : ContentPage
{
    private readonly PromisesViewModel _promisesViewModel;
    public PromisesPage(PromiseRepository promiseRepository, IContextStore contextStore)
    {
        InitializeComponent();
        _promisesViewModel = new PromisesViewModel(promiseRepository, contextStore);
        BindingContext = _promisesViewModel;
    }

    protected override void OnAppearing()
    {
        _promisesViewModel.Reload();
        base.OnAppearing();
    }
}