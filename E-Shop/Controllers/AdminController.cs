using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers;

public class AdminController: Controller

{
    private readonly ILogger<AdminController> _logger2;

    public AdminController(ILogger<AdminController> logger2)
    {
        _logger2 = logger2;
    }
    
    public IActionResult Dashboard()
    {
        return View();
    }
    public IActionResult Dashboard2()
    {
        return View();
    }
    public IActionResult Category()
    {
        return View();
    }

}