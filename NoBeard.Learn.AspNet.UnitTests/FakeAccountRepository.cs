using NoBeard.Learn.AspNet.Data.Repositories;
using NoBeard.Learn.AspNet.Data.Entities;

namespace NoBeard.Learn.AspNet.UnitTests;

internal class FakeAccountRepository : IAccountRepository
{
    // simulacija baze podataka
    private static List<Account> _accounts;

    public FakeAccountRepository()
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
                },
                new Account
                {
                    Id = 3,
                    Name = "Devizni račun",
                    Total = 2000
                }
            ];
        }
    }

    public List<Account> GetAccounts()
    {
        return _accounts;
    }

    public Account? GetAccountById(int id)
    {
        var account = _accounts.SingleOrDefault(x => x.Id == id);

        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = 200 });
        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = -50 });

        return account;
    }

    public void CreateAccount(Account account)
    {
        _accounts.Add(account);
    }

    public void UpdateAccount(int id, Account model)
    {
        var account = GetAccountById(id);

        account.Name = model.Name;
        account.Total = model.Total;
    }

    public void DeleteAccount(int id)
    {
        var account = GetAccountById(id);

        _accounts.Remove(account);
    }
}
