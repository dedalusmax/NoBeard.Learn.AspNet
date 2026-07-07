using NoBeard.Learn.AspNet.Domain.Models;

namespace NoBeard.Learn.AspNet.Domain.Repositories;

public interface IGenericRepository<T> where T : class, IEntity
{
    List<T> GetList();

    T? GetById(int id);

    void Create(T entity);

    void Update(int id, T entity);

    void Delete(int id);
}
