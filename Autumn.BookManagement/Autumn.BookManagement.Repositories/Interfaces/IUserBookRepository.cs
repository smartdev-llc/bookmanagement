using Autumn.BookManagement.Models;

namespace Autumn.BookManagement.Repositories.Interfaces
{
    public interface IUserBookRepository
    {
        Task<IEnumerable<Book>> GetUserBooksByType(Guid userId, string type);
        Task<Guid> AddOrUpdateABook(Guid userId, Guid bookId, string type);
    }
}
