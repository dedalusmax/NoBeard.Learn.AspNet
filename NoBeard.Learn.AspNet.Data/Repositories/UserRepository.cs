using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public void Register(string email)
    {
        throw new NotImplementedException();
    }
}
