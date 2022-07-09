using System.Collections.ObjectModel;
using System.Diagnostics;
using Java.Util;
using Newtonsoft.Json;
using ShoppingList.Context;
using Image = ShoppingList.Models.Image;

namespace ShoppingList.ViewModels;

public class SettingsViewModel : BaseViewModel
{
    private string _name;
    private IContextStore _contextStore;

    public DateTime MaxDate => DateTime.Today;
    // MinDate is Today - 100 years as we think a relation isn't longer than an live
    public DateTime MinDate => DateTime.Today.AddYears(-100);

    public string Name
    {
        get => _contextStore.Name;
        set
        {
            _contextStore.Name = value;
            RaisePropertyChanged();
        }
    }
    public DateTime Date
    {
        get => _contextStore.Date;
        set
        {
            _contextStore.Date = value;
            RaisePropertyChanged();
        }
    }
    
    
    public SettingsViewModel(IContextStore contextStore)
    {
        _contextStore = contextStore;
    }
}