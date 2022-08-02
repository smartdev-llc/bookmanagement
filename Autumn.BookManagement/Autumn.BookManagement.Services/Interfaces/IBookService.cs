using Autumn.BookManagement.Models;

namespace Autumn.BookManagement.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksByName(string? name);
    }
}
