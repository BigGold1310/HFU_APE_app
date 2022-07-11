using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using ShoppingList.Context;
using ShoppingList.Models;
using ShoppingList.Repositories;

namespace ShoppingList.ViewModels;

public class PromisesViewModel : BaseViewModel
{
    private readonly PromiseRepository _promiseRepository;
    private readonly IContextStore _contextStore;

    private ObservableCollection<Promise> _promises;

    public ObservableCollection<Promise> Promises
    {
        get => _promises;
        set
        {
            _promises = value;
            OnPropertyChanged();
        } 
    }

    public PromisesViewModel(PromiseRepository promiseRepository, IContextStore contextStore)
    {
        _promiseRepository = promiseRepository;
        _contextStore = contextStore;
        
        DeleteCommand = new RelayCommand<Promise>((parms) => DeletePromise(parms));
        DetailCommand = new RelayCommand<Promise>((parms) => DetailPromise(parms));
        AddCommand = new RelayCommand(AddPromise);
    }

    public RelayCommand<Promise> DeleteCommand { get; }
    private void DeletePromise(Promise promise)
    {
        _promiseRepository.Delete(promise.Id);
        Promises.Remove(promise);
    }
    
    public RelayCommand<Promise> DetailCommand { get; }
    private async void DetailPromise(Promise promise)
    {
        _contextStore.Promise = promise;
        await Shell.Current.GoToAsync($"/promise");
    }
    
    public RelayCommand AddCommand { get; }
    private async void AddPromise()
    {
        _contextStore.Promise = new Promise();
        await Shell.Current.GoToAsync($"/promise");
    }

    public void Reload()
    {
        Promises = _promiseRepository.GetAll();
    }
}