using CommunityToolkit.Mvvm.Input;
using ShoppingList.Context;
using ShoppingList.Models;
using ShoppingList.Repositories;
using ShoppingList.Validations;

namespace ShoppingList.ViewModels;

[QueryProperty(nameof(Promise), "Promise")]
public class PromiseViewModel : BaseViewModel
{
    private readonly PromiseRepository _promiseRepository;
    private readonly IContextStore _contextStore;
    private readonly IValidation<string> _minTitleLength = new MinLengthValidation(4);
    private readonly IValidation<string> _maxTitleLength = new MaxLengthValidation(40);
    private readonly IValidation<string> _minTextLength = new MinLengthValidation(4);
    private readonly IValidation<string> _maxTextLength = new MaxLengthValidation(500);

    private string _promiseTitle;

    public string PromiseTitle
    {
        get => _promiseTitle;
        set
        {
            _promiseTitle = value;
            RaisePropertyChanged();
        }
    }

    private string _promiseTitleValidation;

    public string PromiseTitleValidation
    {
        get => _promiseTitleValidation;
        set
        {
            _promiseTitleValidation = value;
            RaisePropertyChanged();
        }
    }

    private string _promiseText;

    public string PromiseText
    {
        get => _promiseText;
        set
        {
            _promiseText = value;
            RaisePropertyChanged();
        }
    }

    private string _promiseTextValidation;

    public string PromiseTextValidation
    {
        get => _promiseTextValidation;
        set
        {
            _promiseTextValidation = value;
            RaisePropertyChanged();
        }
    }

    private bool _isNew;
    private DateTime? _created;


    public PromiseViewModel(PromiseRepository promiseRepository, IContextStore contextStore)
    {
        _promiseRepository = promiseRepository;
        _contextStore = contextStore;

        SaveCommand = new RelayCommand(() => SavePromise());
    }

    public RelayCommand SaveCommand { get; }

    private async void SavePromise()
    {

        if (!Validate())
        {
            // We don't save if validation fails
            return;
        }
        if (_isNew)
        {
            _promiseRepository.Create(new Promise() { Created = _created, Text = PromiseText, Title = PromiseTitle });
        }
        else
        {
            _contextStore.Promise.Text = PromiseText;
            _contextStore.Promise.Title = PromiseTitle;
            _promiseRepository.Update(_contextStore.Promise);
        }

        await Shell.Current.GoToAsync("../");
    }

    private bool Validate()
    {
        bool result = true;
        ValidationResult minTitleResult = _minTitleLength.Validate(PromiseTitle);
        ValidationResult maxTitleResult = _maxTitleLength.Validate(PromiseTitle);
        ValidationResult minTextResult = _minTextLength.Validate(PromiseText);
        ValidationResult maxTextResult = _maxTextLength.Validate(PromiseText);
        // Title Validation
        if (minTitleResult.IsValid && maxTitleResult.IsValid)
        {
            PromiseTitleValidation = "";
        }
        else
        {
            result = false;
            if (!minTitleResult.IsValid)
            {
                PromiseTitleValidation = minTitleResult.Message;    
            }
            else if (!maxTitleResult.IsValid)
            {
                PromiseTitleValidation = maxTitleResult.Message;
            }
        }
        // Text validation
        if (minTextResult.IsValid && maxTextResult.IsValid)
        {
            PromiseTitleValidation = "";
        }
        else
        {
            result = false;
            if (!minTextResult.IsValid)
            {
                PromiseTextValidation = minTextResult.Message;    
            }
            else if (!maxTextResult.IsValid)
            {
                PromiseTextValidation = maxTextResult.Message;
            }
        }
        return result;
    }
    public void Init()
    {
        PromiseTextValidation = "";
        PromiseTitleValidation = "";
        if (_contextStore.Promise.Created == null)
        {
            _isNew = true;
            Title = "New";
            PromiseTitle = "";
            PromiseText = "";
            _created = DateTime.Today;
        }
        else
        {
            _isNew = false;
            Title = "Update";
            PromiseTitle = _contextStore.Promise.Title;
            PromiseText = _contextStore.Promise.Text;
            _created = _contextStore.Promise.Created;
        }
    }
}