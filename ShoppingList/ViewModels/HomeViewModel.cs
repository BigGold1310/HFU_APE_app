using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;
using ShoppingList.Context;
using Image = ShoppingList.Models.Image;

namespace ShoppingList.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private Image _randomImage;
    private HttpClient _client;
    private IContextStore _contextStore;

    public string Date => _contextStore.Date.ToString("dd. MMM yyyy");
    public double Days => DateTime.Now.Subtract(_contextStore.Date).TotalDays;
    public double Hours => DateTime.Now.Subtract(_contextStore.Date).TotalHours;
    public double Minutes => DateTime.Now.Subtract(_contextStore.Date).TotalMinutes;
    public double Seconds => DateTime.Now.Subtract(_contextStore.Date).TotalSeconds;
    

    public string Name => _contextStore.Name;

    public Image RandomImage
    {
        get => _randomImage;
        set
        {
            _randomImage = value;
            RaisePropertyChanged();
            // If we update the image we must also update the RandomImageUrl
            RaisePropertyChanged("RandomImageUrl");
        }
    }

    public string RandomImageUrl => _randomImage.Url;

    public HomeViewModel(IContextStore contextStore)
    {
        _client = new HttpClient();
        _randomImage = new Image();
        _contextStore = contextStore;
        
        _contextStore.PropertyChanged += OnContextPropertyChanged;   
        
        Init();
    }
    

    private async void Init()
    {
        int totalImages = await GetTotalImageCount();
        var getImagesTask = await GetRandomImage(totalImages);

        RandomImage = getImagesTask;
    }
    
    private async Task<int> GetTotalImageCount()
    {
        var result = await _client.GetAsync("http://10.0.2.2:3000/photos?_start=1&_limit=1");

        if (result.IsSuccessStatusCode)
        {
            int amountOfImages;
            try
            {
                // Take care, we must check if its null, then we need an empty string.
                amountOfImages = Int32.Parse(result.Headers.GetValues("X-Total-Count").FirstOrDefault() ?? string.Empty);
            }
            catch
            {
                amountOfImages = 0;
            }

            return amountOfImages;
        }

        // TODO: Throw an exception as we don't have any images
        return 0;
    }

    public async Task<Image> GetRandomImage(int totalImages)
    {
        Random rnd = new Random();
        
        if (totalImages != 0)
        {
            var result = await _client.GetAsync($"http://10.0.2.2:3000/photos?_start={rnd.Next(totalImages)}&_limit=1");

            if (result.IsSuccessStatusCode)
            {
                // Do something with the result...
                var stringResult = await result.Content.ReadAsStringAsync();
                List<Image> image;
                try
                {
                    image =
                        JsonConvert.DeserializeObject<List<Image>>(stringResult);
                }
                catch
                {
                    image = new List<Image>();
                    image.Add(new Image());
                    // ignored
                }

                if (image != null) return image.First();
            }
        }
        
        // You might want to throw an exception here since the request was not successful.
        return new Image();
    }

    private void OnContextPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Date":
                RaisePropertyChanged("Date");
                RaisePropertyChanged("Days");
                RaisePropertyChanged("Minutes");
                RaisePropertyChanged("Seconds");
                RaisePropertyChanged("Hours");
                break;
            case "Name":
                RaisePropertyChanged("Name");
                break;
            default:
                break;
        }
    }

    public void Deconstruct(out HttpClient client)
    {
        client = _client;
    }
}