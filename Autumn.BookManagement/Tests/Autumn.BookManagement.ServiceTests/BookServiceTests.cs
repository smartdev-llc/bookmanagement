using Autumn.BookManagement.Repositories;
using Autumn.BookManagement.Services;

namespace Autumn.BookManagement.ServiceTests
{
    public class BookServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        BookService _bookService;

        public BookServiceTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _bookService = new BookService(new BookRepository(_fixture.Context));
        }

        [Fact]
        public async Task BookService_When_GetBooksByNameLowerCaseFreedom_Should_Return2Books()
        {
            var result = await _bookService.GetBooksByName("freedom");

            Assert.Equal(2, result.Count());
            Assert.Contains("freedom", result.First().Name, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task BookService_When_GetBooksByNameKing_Should_ReturnNothing()
        {
            var result = await _bookService.GetBooksByName("King");

            Assert.Empty(result);
        }
    }
}
