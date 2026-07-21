using Microsoft.AspNetCore.Mvc;
using NoBeard.Learn.AspNet.MvcApp.Data;
using NoBeard.Learn.AspNet.MvcApp.Models;
using System.Diagnostics;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetShopContext _context;

        public HomeController(PetShopContext context)
        {
            _context = context;

            var foods = _context.AnimalFoods.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
