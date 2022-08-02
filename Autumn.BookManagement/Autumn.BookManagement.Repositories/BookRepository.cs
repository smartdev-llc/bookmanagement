using Autumn.BookManagement.Models;
using Autumn.BookManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autumn.BookManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksByName(string? name)
        {
            var res = _context.Books.Where(x => string.IsNullOrEmpty(name) || x.Name.ToUpper().Contains(name.ToUpper()));
            return await res.ToListAsync();
        }
    }
}
