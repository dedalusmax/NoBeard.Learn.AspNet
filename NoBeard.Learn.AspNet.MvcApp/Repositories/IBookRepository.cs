using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Repositories;

public interface IBookRepository
{
    IEnumerable<Book> GetBooks();

    Book? GetBook(int id);

    void CreateBook(Book book);

    void UpdateBook(Book book);

    void DeleteBook(int id);
}
