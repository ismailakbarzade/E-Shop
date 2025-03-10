using System.Diagnostics;
using E_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using E_Shop.Models;

namespace E_Shop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext context;
    private readonly IWebHostEnvironment _env;


    
    public HomeController(ApplicationDbContext context,ILogger<HomeController> logger,IWebHostEnvironment env)
    {
        _env = env;
        _logger = logger;
        this.context = context;
    }

    public IActionResult Index()
    {
        var products= context.Products.OrderByDescending(p=>p.Id==1).ToList();
        return View(products);
    }
    
 
    public IActionResult Detail(int id)
    {
        var products= context.Products.Where(p=>p.Id==id).ToList();
        return View(products);
    }
    public IActionResult Shop()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Cart()
    {
        return View();
    }
    public IActionResult Checkout()
    {
        return View();
    }
    public IActionResult Dashboard()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}