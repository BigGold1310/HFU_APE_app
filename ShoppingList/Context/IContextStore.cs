using System.Collections.ObjectModel;
using System.ComponentModel;
using ShoppingList.Models;

namespace ShoppingList.Context;

public interface IContextStore : INotifyPropertyChanged
{
    DateTime Date { get; set; }
    string Name { get; set; }
    Promise Promise { get; set; }
}