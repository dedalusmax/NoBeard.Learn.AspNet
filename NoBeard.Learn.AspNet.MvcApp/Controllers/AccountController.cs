using Microsoft.AspNetCore.Mvc;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers;

public class AccountController : Controller
{
    // simulacija baze podataka
    private static List<Account> _accounts;

    public AccountController()
    {
        if (_accounts is null)
        {
            _accounts =
            [
                new Account
                {
                    Id = 1,
                    Name = "Tekući račun",
                    Total = 200
                },
                new Account
                {
                    Id = 2,
                    Name = "Žiro račun",
                    Total = 0
                }
            ];
        }
    }

    // GET: Account
    public ActionResult Index()
    {
        return View(_accounts);
    }

    // GET: Account/Details/5
    public ActionResult Details(int id)
    {
        var account = _accounts.SingleOrDefault(x => x.Id == id);

        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = 200 });
        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = -50 });

        return View(account);
    }

    // GET: Account/Create
    public ActionResult Create()
    {
        return View(new Account());
    }

    // POST: Account/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Account model)
    {
        try
        {
            _accounts.Add(model);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Account/Edit/5
    public ActionResult Edit(int id)
    {
        var account = _accounts.SingleOrDefault(x => x.Id == id);

        return View(account);
    }

    // POST: Account/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Account model)
    {
        try
        {
            var account = _accounts.SingleOrDefault(x => x.Id == id);

            account.Name = model.Name;
            account.Total = model.Total;

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Account/Delete/5
    public ActionResult Delete(int id)
    {
        var account = _accounts.SingleOrDefault(x => x.Id == id);

        return View(account);
    }

    // POST: Account/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            var account = _accounts.SingleOrDefault(x => x.Id == id);

            _accounts.Remove(account);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
