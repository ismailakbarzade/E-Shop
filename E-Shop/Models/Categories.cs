namespace E_Shop.Models;

public class Categories
{
    public int id { get; set; }
    public string name { get; set; }
    public string desc { get; set; }
    public ICollection<Product> products { get; set; }
}