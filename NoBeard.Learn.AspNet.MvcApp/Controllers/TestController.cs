using Microsoft.AspNetCore.Mvc;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Indeks()
    {
        return View("Index");
    }

    public IActionResult Redirect()
    {
        return Redirect("/Home/Privacy");
    }
}
