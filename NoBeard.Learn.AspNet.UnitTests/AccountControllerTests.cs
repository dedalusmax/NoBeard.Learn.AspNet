using Microsoft.AspNetCore.Mvc;
using NoBeard.Learn.AspNet.MvcApp.Controllers;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.UnitTests;

public class AccountControllerTests
{
    [Fact]
    public void AccountController_Index_ReturnsView()
    {
        // arrange
        var controller = new AccountController();

        // act
        var result = controller.Index();

        // assert
        Assert.IsAssignableFrom<IActionResult>(result);
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void AccountController_Index_ReturnsTwoAccounts()
    {
        // arrange
        var controller = new AccountController();

        // act
        var result = controller.Index() as ViewResult;

        // assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.IsAssignableFrom<List<Account>>(result.Model);
        var accounts = result.Model as List<Account>;
        Assert.NotNull(accounts);
        Assert.Equal(2, accounts.Count); 
    }

    [Fact]
    public void AccountController_Details_ReturnsAccount()
    {
        // arrange
        var controller = new AccountController();

        // act
        var result = controller.Details(2) as ViewResult;

        // assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        var account = Assert.IsType<Account>(result.Model);
        Assert.NotNull(account);
        Assert.Equal(2, account.Id);
        Assert.Equal("Žiro račun", account.Name);
        Assert.Equal(0, account.Total);
        Assert.NotNull(account.Transactions);
        Assert.NotEmpty(account.Transactions);
        Assert.Equal(2, account.Transactions.Count);
    }

    [Fact]
    public void AccountController_PostCreate_RedirectsToIndex()
    {
        // arrange
        var controller = new AccountController();
        var newAccount = new Account { Id = 3, Name = "Testni račun", Total = 100 };

        // act
        var result = controller.Create(newAccount);

        // assert
        var action = Assert.IsType<RedirectToActionResult>(result);
        Assert.NotNull(action);
        Assert.Equal("Index", action.ActionName);
    }

    [Fact]
    public void AccountController_PostCreate_AccountCreated()
    {
        // arrange
        var controller = new AccountController();
        var newAccount = new Account { Id = 3, Name = "Testni račun", Total = 100 };

        // act
        controller.Create(newAccount);
        var result = controller.Index() as ViewResult;

        // assert
        var accounts = result!.Model as List<Account>;
        Assert.NotNull(accounts);
        Assert.Equal(3, accounts.Count);
    }
}
