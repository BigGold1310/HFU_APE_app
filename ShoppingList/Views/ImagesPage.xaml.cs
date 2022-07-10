using System.Diagnostics;
using ShoppingList.ViewModels;

namespace ShoppingList.Views;

public partial class ImagesPage : ContentPage
{
    public ImagesPage()
    {
        InitializeComponent();
        BindingContext = new ImagesViewModel();
    }
    
    void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        // Custom logic
        // TODO: Implement on scroll load of more items (call view model function maybe...??)
        // Be carefull with the code as this Event handler gets called many times...
        Debug.WriteLine(e.LastVisibleItemIndex);
    }
}