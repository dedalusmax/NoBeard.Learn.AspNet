using Microsoft.Data.SqlClient;
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

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        using var command = new SqlCommand("SELECT * FROM Book", connection);

        using var reader = command.ExecuteReader();

        var books = new List<Book>();
        while (reader.Read())
        {
            var book = new Book
            {
                BookId = reader.GetInt32(0),
                Author = reader.GetInt32(1),
                Title = reader.GetString(2),
                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                Genre = reader.IsDBNull(4) ? null : reader.GetString(4),
                Stock = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                ReleaseDate = reader.GetDateTime(6)
            };
            books.Add(book);
        }

        return books;
    }
}
