using Autumn.BookManagement.Models;

namespace Autumn.BookManagement.Services.Interfaces
{
    public interface IUserBookService
    {
        Task<IEnumerable<Book>> GetUserBooksByType(Guid userId, string type);
        Task<Guid> AddOrUpdateABook(Guid userId, Guid bookId, string type);
    }
}
