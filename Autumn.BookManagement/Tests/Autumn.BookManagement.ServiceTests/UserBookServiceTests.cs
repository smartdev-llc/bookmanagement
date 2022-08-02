using Autumn.BookManagement.Models;
using Autumn.BookManagement.Repositories;
using Autumn.BookManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace Autumn.BookManagement.ServiceTests
{
    public class UserBookServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        UserBookService _userBookService;

        public UserBookServiceTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _userBookService = new UserBookService(new UserBookRepository(_fixture.Context));
        }

        [Fact]
        public async Task UserBookService_When_AddBookToUserBookList_Then_ARecordIsAdded()
        {
            var userId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var book1Id = Guid.Parse("00000000-0000-0000-0000-000000000001");
            await _userBookService.AddOrUpdateABook(userId, book1Id, UserBookConstants.TYPE_READ);

            var book4Id = Guid.Parse("00000000-0000-0000-0000-000000000004");
            await _userBookService.AddOrUpdateABook(_fixture.User1Id, book4Id, UserBookConstants.TYPE_READ);

            var userBooksInDb = await _fixture.Context.UserBooks.ToListAsync();
            Assert.Equal(5, userBooksInDb.Count);
            Assert.Contains(userBooksInDb, a => a.UserId.Equals(userId) && a.BookId.Equals(book1Id) && a.Type == UserBookConstants.TYPE_READ);
            Assert.Contains(userBooksInDb, a => a.UserId.Equals(_fixture.User1Id) && a.BookId.Equals(book4Id) && a.Type == UserBookConstants.TYPE_READ);
        }

        [Fact]
        public async Task UserBookService_AddBookToUserBookList_Throws_InvalidDataException()
        {
            var userId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var book1Id = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var act = async () => await _userBookService.AddOrUpdateABook(userId, book1Id, "Another type");

            var exception = await Assert.ThrowsAsync<InvalidDataException>(act);
            Assert.Equal("Type is not valid", exception.Message);
        }

        [Fact]
        public async Task UserBookService_When_GetCompletedBooks_Should_ReturnListOfBooks()
        {
            var result = await _userBookService.GetUserBooksByType(_fixture.User1Id, UserBookConstants.TYPE_COMPLETED);

            Assert.Equal(2, result.Count());
        }
    }
}
