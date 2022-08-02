using Autumn.BookManagement.Models;
using Autumn.BookManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autumn.BookManagement.Repositories
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBook> UserBooks { get; set; }

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
