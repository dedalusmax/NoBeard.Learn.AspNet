using Microsoft.AspNetCore.Mvc;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers;

public class BookController : Controller
{
    private readonly IConfiguration _configuration;

    public BookController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // GET: BookController
    public ActionResult Index()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        


        return View();
    }

    // GET: BookController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: BookController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BookController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BookController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: BookController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BookController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: BookController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
