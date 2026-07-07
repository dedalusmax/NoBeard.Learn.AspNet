using NoBeard.Learn.AspNet.Data.Entities;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public interface IAccountRepository
{
    List<Account> GetAccounts();

    Account? GetAccountById(int id);

    void CreateAccount(Account account);

    void UpdateAccount(int id, Account model);

    void DeleteAccount(int id);
}
