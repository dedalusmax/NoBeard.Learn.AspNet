using NoBeard.Learn.AspNet.Domain.Models;

namespace NoBeard.Learn.AspNet.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    void Register(string email);
}
