namespace ShoppingList.Models;

public class Image
{
    public int Id { get; set; }
    public int AlbumId { get; set; }
    public string Url { get; set; }
    public string ThumbnailUrl { get; set; }
    public string Title { get; set; }
}