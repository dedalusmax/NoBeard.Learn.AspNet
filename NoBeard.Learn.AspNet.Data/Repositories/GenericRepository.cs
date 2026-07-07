using NoBeard.Learn.AspNet.Domain.Models;
using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class GenericRepository<T> : ReadOnlyRepository<T>, IGenericRepository<T> where T : class, IEntity
{
    public T? GetById(int id)
    {
        var entity = _entities.SingleOrDefault(x => x.Id == id);

        return entity;
    }

    public void Create(T model)
    {
        _entities.Add(model);
    }

    public void Update(int id, T model)
    {
        var entity = GetById(id);

        //entity.Name = model.Name;
        //entity.Total = model.Total;
    }

    public void Delete(int id)
    {
        var entity = GetById(id);

        _entities.Remove(entity);
    }
}
