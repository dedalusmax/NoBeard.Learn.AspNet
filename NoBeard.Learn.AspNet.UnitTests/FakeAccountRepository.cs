using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

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

    public List<Account> GetList()
    {
        return _accounts;
    }

    public Account? GetById(int id)
    {
        var account = _accounts.SingleOrDefault(x => x.Id == id);

        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = 200 });
        account.Transactions.Add(new() { Id = Guid.NewGuid(), Amount = -50 });

        return account;
    }

    public void Create(Account account)
    {
        _accounts.Add(account);
    }

    public void Update(int id, Account model)
    {
        var account = GetById(id);

        account.Name = model.Name;
        account.Total = model.Total;
    }

    public void Delete(int id)
    {
        var account = GetById(id);

        _accounts.Remove(account);
    }
}
