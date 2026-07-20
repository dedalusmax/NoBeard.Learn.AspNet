using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NoBeard.Learn.AspNet.MvcApp.Models;

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
        
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand("SELECT * FROM Book", connection);

        using var reader = command.ExecuteReader();

        var books = new List<Book>();
        while (reader.Read())
        {
            var book = new Book
            {
                BookId = reader.GetInt32(0),
                Author = reader.GetInt32(1),
                Title = reader.GetString(2),
                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                Genre = reader.IsDBNull(4) ? null : reader.GetString(4),
                Stock = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                ReleaseDate = reader.GetDateTime(6)
            };
            books.Add(book);
        }

        return View(books);
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
