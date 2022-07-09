using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ShoppingList.Helpers;

public abstract class MyPropertyChanged : INotifyPropertyChanged
{
    
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        this.PropertyChanged?.Invoke(this, e);
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        VerifyPropertyName(propertyName);
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }
    
    /// <summary>
    /// Warnt den Compiler, falls es zum spezifizierten Namen kein Property im Objekt existiert.
    /// Diese Methode ist nur für Debug Build.
    /// </summary>
    [Conditional("DEBUG")]
    [DebuggerStepThrough]
    protected void VerifyPropertyName(string propertyName)
    {
        // Sicherstellen, dass der Proterty Name auf dem Objekt exisiert  
        if (TypeDescriptor.GetProperties(this)[propertyName] == null)
        {
            Debug.Fail("Invalid property name: " + propertyName);
        }
    }
}