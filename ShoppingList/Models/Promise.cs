using SQLite;

namespace ShoppingList.Models;

[Table("promises")]
public class Promise
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }
    
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
}