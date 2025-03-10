using E_Shop.Data;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers;

public class ProductsController: Controller
{
    private readonly ApplicationDbContext context;
    private readonly IWebHostEnvironment _env;

    public ProductsController(ApplicationDbContext context,IWebHostEnvironment env)
    {
        this.context = context;
        _env = env;
    }
    public IActionResult Products()
    {
        var products= context.Products.OrderByDescending(p=>p.Id).ToList();
        return View(products);
    }

    public IActionResult ProductDetails(int id)
    {
        var products= context.Products.Where(p=>p.IdCategory==id).ToList();
        return View(products);
    }
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(ProductDto productDto)
    {
        if (productDto.Image == null)
        {
            ModelState.AddModelError("Image", "Image is required.");
        }

        if (!ModelState.IsValid)
        {
            return View(productDto);
        }
        
        string fileName=Path.GetFileName(productDto.Image!.FileName);
        string imageFullPath = _env.WebRootPath + "/" + fileName;
        using (var stream= System.IO.File.Create(imageFullPath))
        {
            productDto.Image.CopyTo(stream);
        }

        Product product = new Product()
        {
            Name = productDto.Name,
            Avaible = productDto.Avaible,
            Price = productDto.Price,
            Color = productDto.Color,
            IsFavorite = productDto.IsFavorite,
            UrlImage = fileName,
            Size = productDto.Size,
            LongDesc = productDto.LongDesc,
            ShortDesc = productDto.ShortDesc,
            IdCategory = productDto.IdCategory,
            

        };
        
        context.Products.Add(product);
        context.SaveChanges();
        
        return RedirectToAction("Dashboard2", "Admin");
    }

    public IActionResult Edit(int id)
    {
        var product = context.Products.Find(id);
        if (product == null)
        {
            return RedirectToAction("Dashboard2", "Admin");
        }

        var productDto = new ProductDto()
        {
            LongDesc = product.LongDesc,
            ShortDesc = product.ShortDesc,
            Name = product.Name,
            Price = product.Price,
            Color = product.Color,
            Size = product.Size,
            IdCategory = product.IdCategory,
            IsFavorite = product.IsFavorite,
            Avaible = product.Avaible,
        };
        ViewData["ProductId"] = product.Id;
        ViewData["Image"] = product.UrlImage;
        context.Products.Update(product);
        context.SaveChanges();

        return View(productDto);
    }

    [HttpPost]
    public IActionResult Edit(int id,ProductDto productDto)
    {
        var product = context.Products.Find(id);
        if (product == null)
        {
            return RedirectToAction("Dashboard2", "Admin");
        }

        if (!ModelState.IsValid)
        {
            ViewData["ProductId"] = product.Id;
            ViewData["Image"] = product.UrlImage;
            return View(productDto);
        }

        string newFileName = product.UrlImage;
        if (productDto.Image != null)
        {
            newFileName = Path.GetFileName(productDto.Image!.FileName);
            string imageFullPath = _env.WebRootPath + "/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productDto.Image.CopyTo(stream);
            }
            string oldImagePath = _env.WebRootPath + "/" + product.UrlImage;
            System.IO.File.Delete(oldImagePath);
        }

        product.Name = productDto.Name;
        product.Avaible = productDto.Avaible;
        product.Price = productDto.Price;
        product.Color = productDto.Color;
        product.IsFavorite = productDto.IsFavorite;
        product.UrlImage = newFileName;
        product.Size = productDto.Size;
        product.LongDesc = productDto.LongDesc;
        product.ShortDesc = productDto.ShortDesc;
        product.IdCategory = productDto.IdCategory;
        context.SaveChanges();
        return RedirectToAction("Dashboard2", "Admin");
    }

    public IActionResult Delete(int id)
    {
        var product = context.Products.Find(id);
        if (product == null)
        {
            return RedirectToAction("Dashboard2", "Admin");
        }
        string imagePath = _env.WebRootPath + "/" + product.UrlImage;
        System.IO.File.Delete(imagePath);
        context.Products.Remove(product);
        context.SaveChanges(true);
        return RedirectToAction("Dashboard2", "Admin");
        
    }
}