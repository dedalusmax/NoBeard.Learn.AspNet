using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NoBeard.Learn.AspNet.Domain.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers;

public class InvoiceController : Controller
{
    private readonly SqlConnection _connection;

    public InvoiceController(IConfiguration configuration)
    {
        //var connectionString = "Server=(localdb)\\mssqllocaldb;Database=invoices;Trusted_Connection=true;";
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }

    // GET: InvoiceController
    public ActionResult Index()
    {
        if (_connection.State != System.Data.ConnectionState.Open)
        {
            _connection.Open();
        }

        using var command = new SqlCommand("SELECT InvoiceNumber, DateOfIssue FROM Invoices ORDER BY InvoiceNumber", _connection);

        using SqlDataReader reader = command.ExecuteReader();

        var result = new List<Invoice>();
        while (reader.Read())
        {
            var invoice = new Invoice
            {
                InvoiceNumber = reader.GetInt32(0),
                DateOfIssue = reader.GetDateTime(1)
            };
            result.Add(invoice);
        }

        return View(result);
    }

    // GET: InvoiceController/Details/5
    public ActionResult Details(int id)
    {
        if (_connection.State != System.Data.ConnectionState.Open)
        {
            _connection.Open();
        }

        using var command = new SqlCommand("SELECT InvoiceNumber, DateOfIssue FROM Invoices WHERE InvoiceNumber = @id", _connection);
        //command.Parameters.Add(new SqlParameter("@id", id));        
        command.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = command.ExecuteReader();

        reader.Read();

        var invoice = new Invoice
        {
            InvoiceNumber = reader.GetInt32(0),
            DateOfIssue = reader.GetDateTime(1)
        };

        return View(invoice);
    }

    // GET: InvoiceController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: InvoiceController/Create
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

    // GET: InvoiceController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: InvoiceController/Edit/5
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

    // GET: InvoiceController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: InvoiceController/Delete/5
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

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_connection is not null)
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }

        base.Dispose(disposing);
    }
   
}
