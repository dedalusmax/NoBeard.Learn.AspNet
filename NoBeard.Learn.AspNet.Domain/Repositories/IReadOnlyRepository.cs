namespace NoBeard.Learn.AspNet.Domain.Repositories;

public interface IReadOnlyRepository<T> where T : class
{
    List<T> GetList();
}
