using Autumn.BookManagement.Models;
using Autumn.BookManagement.Repositories.Interfaces;
using Autumn.BookManagement.Services.Interfaces;

namespace Autumn.BookManagement.Services
{
    public class UserBookService : IUserBookService
    {
        private readonly IUserBookRepository _userBookRepository;

        public UserBookService(IUserBookRepository userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<IEnumerable<Book>> GetUserBooksByType(Guid userId, string type)
        {
            return await _userBookRepository.GetUserBooksByType(userId, type);
        }

        public async Task<Guid> AddOrUpdateABook(Guid userId, Guid bookId, string type)
        {
            if (UserBookConstants.Types.All(t => t != type))
            {
                throw new InvalidDataException("Type is not valid");
            }

            return await _userBookRepository.AddOrUpdateABook(userId, bookId, type);
        }
    }
}
