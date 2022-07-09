using System.ComponentModel;

namespace ShoppingList.Context;

public interface IContextStore : INotifyPropertyChanged
{
    DateTime Date { get; set; }
    string Name { get; set; }
}