using CommunityToolkit.Mvvm.Input;
using ShoppingList.Context;
using ShoppingList.Models;
using ShoppingList.Repositories;

namespace ShoppingList.ViewModels;

[QueryProperty(nameof(Promise), "Promise")]
public class PromiseViewModel : BaseViewModel
{
    private readonly PromiseRepository _promiseRepository;
    private readonly IContextStore _contextStore;

    private Promise _promise;

    public Promise Promise
    {
        get => _promise;
        set => _promise = value;
    }

    public PromiseViewModel(PromiseRepository promiseRepository, IContextStore contextStore)
    {
        _promiseRepository = promiseRepository;
        _contextStore = contextStore;

        DeleteCommand = new RelayCommand<int>((parms) => DeletePromise(parms));
    }

    public RelayCommand<int> DeleteCommand { get; }
    private void DeletePromise(int id)
    {
        _promiseRepository.Delete(id);
    }

    
}