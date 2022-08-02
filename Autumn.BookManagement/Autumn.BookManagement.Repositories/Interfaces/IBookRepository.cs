using Autumn.BookManagement.Models;

namespace Autumn.BookManagement.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksByName(string? name);
    }
}
