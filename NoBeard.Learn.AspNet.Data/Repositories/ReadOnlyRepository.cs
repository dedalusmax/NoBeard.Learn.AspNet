using NoBeard.Learn.AspNet.Domain.Repositories;

namespace NoBeard.Learn.AspNet.Data.Repositories;

public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
{
    // simulacija baze podataka
    protected static List<T> _entities = [];

    public List<T> GetList()
    {
        return _entities;
    }
}
