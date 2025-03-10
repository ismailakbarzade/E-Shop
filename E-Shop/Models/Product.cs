namespace E_Shop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public ushort Price { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public bool IsFavorite { get; set; }
    public bool Avaible { get; set; }
    public string UrlImage { get; set; }
    public int IdCategory { get; set; }
    
    
}