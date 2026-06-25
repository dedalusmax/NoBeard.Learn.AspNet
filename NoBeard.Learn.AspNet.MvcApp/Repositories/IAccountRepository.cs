using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Repositories;

public interface IAccountRepository
{
    List<Account> GetAccounts();

    Account? GetAccountById(int id);

    void CreateAccount(Account account);

    void UpdateAccount(int id, Account model);

    void DeleteAccount(int id);
}
