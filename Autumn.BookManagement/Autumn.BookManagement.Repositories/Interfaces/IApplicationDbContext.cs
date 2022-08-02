using Autumn.BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Autumn.BookManagement.Repositories.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserBook> UserBooks { get; set; }
    }
}