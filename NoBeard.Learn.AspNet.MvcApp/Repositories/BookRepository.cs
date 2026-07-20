using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IConfiguration _configuration;

    public BookRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        return [];
    }
}
