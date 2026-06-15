using Microsoft.AspNetCore.Mvc;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers;

public class AccountController : Controller
{
    // GET: Account
    public ActionResult Index()
    {
        var account = new Account        
        {
            Id = 1,
            Name = "Tekući račun",
            Total = 200
        };
        
        var accounts = new List<Account> { account };

        return View(accounts);
    }

    // GET: Account/Details/5
    public ActionResult Details(int id)
    {
        var account = new Account
        {
            Id = 5,
            Name = "Tekući račun",
            Total = 200
        };

        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = 200 });
        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = -50 });

        return View(account);
    }

    // GET: AccountController/Create
    public ActionResult Create()
    {
        return View(new Account());
    }

    // POST: AccountController/Create
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

    // GET: AccountController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: AccountController/Edit/5
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

    // GET: AccountController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: AccountController/Delete/5
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
