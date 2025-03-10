using E_Shop.Data;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers;

public class AdminController: Controller

{
    private readonly ILogger<AdminController> _logger2;
    private readonly ApplicationDbContext context;
    private readonly IWebHostEnvironment _env;


    public AdminController(ApplicationDbContext context,ILogger<AdminController> logger2,IWebHostEnvironment env)
    {
        this.context = context;
        _logger2 = logger2;
        _env = env;
    }
    
    public IActionResult Dashboard()
    {
        return View();
    }
    public IActionResult Dashboard2()
    {
        var products= context.Products.OrderByDescending(p=>p.Id).ToList();
        return View(products);
    }
    public IActionResult Category()
    {
        return View();
    }

}