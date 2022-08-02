using Autumn.BookManagement.Models;
using Autumn.BookManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autumn.BookManagement.Apis.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooksByName(string? name)
            => await _bookService.GetBooksByName(name);
    }
}