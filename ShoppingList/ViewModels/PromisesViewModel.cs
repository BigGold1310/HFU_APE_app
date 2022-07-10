using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingList.Models;
using ShoppingList.Repositories;

namespace ShoppingList.ViewModels;

public class PromisesViewModel : BaseViewModel
{
    private readonly PromiseRepository _promiseRepository;

    private ObservableCollection<Promise> _promises;

    public ObservableCollection<Promise> Promises
    {
        get => _promises;
        set => _promises = value;
    }

    public PromisesViewModel(PromiseRepository promiseRepository)
    {
        _promiseRepository = promiseRepository;

        Promises = new ObservableCollection<Promise>()
        {
            new Promise() { Title = "Test 1", Text = "Test11", Created = DateTime.Now },
            new Promise() { Title = "Test 2", Text = "Test12", Created = DateTime.Now },
            new Promise() { Title = "Test 3", Text = "Test13", Created = DateTime.Now },
            new Promise() { Title = "Test 1", Text = "Test11", Created = DateTime.Now },
            new Promise() { Title = "Test 2", Text = "Test12", Created = DateTime.Now },
            new Promise() { Title = "Test 3", Text = "Test13", Created = DateTime.Now },
            new Promise() { Title = "Test 1", Text = "Test11", Created = DateTime.Now },
            new Promise() { Title = "Test 2", Text = "Test12", Created = DateTime.Now },
            new Promise() { Title = "Test 3", Text = "Test13", Created = DateTime.Now },
        };
        DeleteCommand = new RelayCommand<int>((parms) => DeletePromise(parms));
        DetailCommand = new RelayCommand<Promise>((parms) => DetailPromise(parms));
    }

    public RelayCommand<int> DeleteCommand { get; }
    private void DeletePromise(int id)
    {
        _promiseRepository.Delete(id);
    }
    
    public RelayCommand<Promise> DetailCommand { get; }
    private async void DetailPromise(Promise promise)
    {
        await Shell.Current.GoToAsync($"/promise?Promise={promise}");
    }
    
    
}