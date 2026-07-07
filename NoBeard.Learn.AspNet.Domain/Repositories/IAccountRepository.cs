using NoBeard.Learn.AspNet.Domain.Models;

namespace NoBeard.Learn.AspNet.Domain.Repositories;

public interface IAccountRepository
{
    List<Account> GetAccounts();

    Account? GetAccountById(int id);

    void CreateAccount(Account account);

    void UpdateAccount(int id, Account model);

    void DeleteAccount(int id);
}
