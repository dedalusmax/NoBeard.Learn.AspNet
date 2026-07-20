using NoBeard.Learn.AspNet.MvcApp.Data;
using NoBeard.Learn.AspNet.MvcApp.Models;

namespace NoBeard.Learn.AspNet.MvcApp.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookLibraryContext _context;

    public BookRepository(BookLibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetBooks()
    {
        return _context.Books;
    }

    public Book? GetBook(int id)
    {
        return _context.Books.Find(id);
    }

    public void CreateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(int id)
    {
        throw new NotImplementedException();
    }
}
