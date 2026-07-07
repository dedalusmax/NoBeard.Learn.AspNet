using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class AccountTypeRepository : ReadOnlyRepository<AccountType>, IAccountTypeRepository
{
}
