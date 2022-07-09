using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Image = ShoppingList.Models.Image;

namespace ShoppingList.ViewModels;

public class ImagesViewModel : BaseViewModel
{
    private ObservableCollection<Image> _images;
    private HttpClient _client;

    public ObservableCollection<Image> Images
    {
        get => _images;
        set
        {
            _images = value;
            RaisePropertyChanged();
        }
    }

    public ImagesViewModel()
    {
        _client = new HttpClient();

        Init();
    }

    private async void Init()
    {
        var getImagesTask = await GetImages();

        Images = getImagesTask;
    }
    
    public async Task<ObservableCollection<Image>> GetImages()
    {
        var result = await _client.GetAsync("http://10.0.2.2:3000/photos?_page=1&_limit=30");

        if (result.IsSuccessStatusCode)
        {
            // Do something with the result...
            var stringResult = await result.Content.ReadAsStringAsync();
            ObservableCollection<Image> images;
            try
            {
                images =
                    JsonConvert.DeserializeObject<ObservableCollection<Image>>(stringResult);
            }
            catch
            {
                images = new ObservableCollection<Image>();
                // ignored
            }

            return images;
        }

        // You might want to throw an exception here since the request was not successful.
        return new ObservableCollection<Image>();
    }
    
    public void Deconstruct(out HttpClient client)
    {
        client = _client;
    }
}