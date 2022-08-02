using Autumn.BookManagement.Models;
using Autumn.BookManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autumn.BookManagement.Repositories
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly ApplicationDbContext _context;

        public UserBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetUserBooksByType(Guid userId, string type)
        {
            var res = _context.UserBooks
                .Where(u => u.UserId == userId && u.Type == type)
                .Join(_context.Books, u => u.BookId, b => b.Id, (u, b) => b);

            return await res.ToListAsync();
        }

        public async Task<Guid> AddOrUpdateABook(Guid userId, Guid bookId, string type)
        {
            var existingEntity = await _context.UserBooks
                .FirstOrDefaultAsync(u => u.UserId == userId && u.BookId == bookId);

            if (existingEntity == null)
            {
                existingEntity = new UserBook
                {
                    UserId = userId,
                    BookId = bookId,
                    Type = type
                };
                _context.UserBooks.Add(existingEntity);
            }
            else
            {
                existingEntity.Type = type;
                _context.UserBooks.Update(existingEntity);
            }
            await _context.SaveChangesAsync();

            return existingEntity.Id;
        }
    }
}
