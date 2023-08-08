using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _3_CRUDelicious.Models;

namespace _3_CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.OrderBy(d => d.CreatedAt).ToList();
        return View(AllDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("New");
        }
    }

    [HttpGet("dishes/{DishId}")]
    public IActionResult Show(int DishId)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        return View("Show", OneDish);
    }

    [HttpGet("dishes/{DishId}/edit")]
    public IActionResult Edit(int DishId)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        return View("Edit", OneDish);
    }

    [HttpPost("dishes/{DishId}/update")]
    public IActionResult Update(Dish newDish, int DishId)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        if (ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.Description = newDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Show", new { DishId = DishId});
        } else {
            return View("Edit", OldDish);
        }
    }

    [HttpPost("dishes/{DishId}/destroy")]
    public IActionResult Destroy(int DishId)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == DishId);
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
