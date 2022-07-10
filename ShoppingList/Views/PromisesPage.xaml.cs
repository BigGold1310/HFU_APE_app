using ShoppingList.Repositories;
using ShoppingList.ViewModels;

namespace ShoppingList.Views;

public partial class PromisesPage : ContentPage
{
    public PromisesPage(PromiseRepository promiseRepository)
    {
        InitializeComponent();
        BindingContext = new PromisesViewModel(promiseRepository);
    }
}