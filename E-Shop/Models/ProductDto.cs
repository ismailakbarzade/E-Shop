using System.ComponentModel.DataAnnotations;

namespace E_Shop.Models;

public class ProductDto
{
    
    public string Name { get; set; }
    
    public string ShortDesc { get; set; }
    
    public string LongDesc { get; set; }
    
    public ushort Price { get; set; }
    
    public string Size { get; set; }
    
    public string Color { get; set; }
  
    public bool IsFavorite { get; set; } = true;

   
    public bool Avaible { get; set; } = true;

    public int IdCategory { get; set; } = 1;
    
    public IFormFile? Image { get; set; }
} 

