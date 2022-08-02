using Autumn.BookManagement.Models;
using Autumn.BookManagement.Repositories.Interfaces;
using Autumn.BookManagement.Services.Interfaces;

namespace Autumn.BookManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksByName(string? name)
        {
            return await _bookRepository.GetBooksByName(name);
        }
    }
}
