using Autumn.BookManagement.Models;
using Autumn.BookManagement.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Autumn.BookManagement.ServiceTests
{
    public class DatabaseFixture: IDisposable
    {
        private const string ConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        public ApplicationDbContext Context { get; private set; }
        public Guid User1Id { get; private set; }

        public DatabaseFixture()
        {
            _connection = new SqliteConnection(ConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options;
            Context = new ApplicationDbContext(options);
            Context.Database.EnsureCreated();

            PrepareData();
        }

        private void PrepareData()
        {
            User1Id = Guid.Parse("00000000-0000-0000-0000-000000000001");

            var users = new List<User>()
            {
                new User() { Id = User1Id, Name = "Mary" },
                new User() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Olov" },
            };

            Context.Users.AddRange(users);

            var authors = new List<Author>()
            {
                new Author() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Nikos Kazantzakis" },
                new Author() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Nelson Mandela" },
            };

            Context.Authors.AddRange(authors);

            Context.SaveChanges();

            var books = new List<Book>()
            {
                new Book() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Zorba the Greek", AuthorId = authors[0].Id },
                new Book() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Freedom or Death", AuthorId = authors[0].Id },
                new Book() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Long Walk to Freedom", AuthorId = authors[1].Id },
                new Book() { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Conversations With Myself", AuthorId = authors[1].Id },
            };

            Context.Books.AddRange(books);

            var userBooks = new List<UserBook>()
            {
                new UserBook() { UserId = User1Id, BookId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Type = UserBookConstants.TYPE_READ, Id = Guid.NewGuid() },
                new UserBook() { UserId = User1Id, BookId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Type = UserBookConstants.TYPE_COMPLETED, Id = Guid.NewGuid() },
                new UserBook() { UserId = User1Id, BookId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Type = UserBookConstants.TYPE_COMPLETED, Id = Guid.NewGuid() },
                new UserBook() { UserId = User1Id, BookId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Type = UserBookConstants.TYPE_FAVOURITE, Id = Guid.NewGuid() },
            };

            Context.UserBooks.AddRange(userBooks);

            Context.SaveChanges();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
