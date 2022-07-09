using ShoppingList.Helpers;

namespace ShoppingList.Context;

public class ContextStore : MyPropertyChanged, IContextStore
{
    public DateTime Date
    {
        get
        {
            if (DateTime.TryParse(Preferences.Default.Get("date", ""), out var dateTime))
            {
                Console.WriteLine(dateTime);
            }
            else
            {
                dateTime = new DateTime();
            }

            return dateTime;
        }
        set
        {
            Preferences.Default.Set("date", value.ToString());
            RaisePropertyChanged();
        }
    }

    public string Name
    {
        get => Preferences.Default.Get("name", "");
        set
        {
            Preferences.Default.Set("name", value);
            RaisePropertyChanged();
        }
    }
}