using Microsoft.AspNetCore.Mvc;
using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.MvcApp.Controllers;

public class AccountController : Controller
{
    private readonly IAccountRepository _repository;

    public AccountController(IAccountRepository repository)
    {
        if (repository is null)
            throw new ArgumentNullException(nameof(repository));

        _repository = repository;
    }

    // GET: Account
    public ActionResult Index()
    {
        return View(_repository.GetAccounts());
    }

    // GET: Account/Details/5
    public ActionResult Details(int id)
    {
        return View(_repository.GetAccountById(id));
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
            _repository.CreateAccount(model);

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
        return View(_repository.GetAccountById(id));
    }

    // POST: Account/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Account model)
    {
        try
        {
            _repository.UpdateAccount(id, model);

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
        return View(_repository.GetAccountById(id));
    }

    // POST: Account/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _repository.DeleteAccount(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
