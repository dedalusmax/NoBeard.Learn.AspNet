using NoBeard.Learn.AspNet.Data.Entities;
using NoBeard.Learn.AspNet.Data.Repositories;

namespace NoBeard.Learn.AspNet.Business.Services;

public interface IAccountService
{
    Task OpenAccountAsync(string name, decimal initial);
}

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository repository)
    {
        _accountRepository = repository;
    }

    public Task OpenAccountAsync(string name, decimal initial)
    {
        var entity = new Account()
        {
            Name = name,
            Total = initial
        };

        _accountRepository.CreateAccount(entity);

        return Task.CompletedTask;
    }
}
