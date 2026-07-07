using Microsoft.AspNetCore.Mvc;
using NoBeard.Learn.AspNet.Domain.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Pozdrav, ekipa!";
        ViewBag.Message = "Pozdrav, ekipa!";

        ViewBag.Account = new Account() { Id = 200, Name = "Testni" };

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
