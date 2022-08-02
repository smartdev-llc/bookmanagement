using Autumn.BookManagement.Apis.Models;
using Autumn.BookManagement.Models;
using Autumn.BookManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autumn.BookManagement.Apis.Controllers
{
    [ApiController]
    [Route("user-books")]
    public class UserBookController : ControllerBase
    {
        private readonly IUserBookService _userBookService;

        public UserBookController(IUserBookService userBookService)
        {
            _userBookService = userBookService;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Book>> GetUserBooksByType(Guid userId, [FromQuery] string type)
            => await _userBookService.GetUserBooksByType(userId, type);

        [HttpPost("{userId}")]
        public async Task<ActionResult<Guid>> AddOrUpdateABook(Guid userId, [FromBody] UserBookRequestModel requestModel)
        {
            try
            {
                return await _userBookService.AddOrUpdateABook(userId, requestModel.BookId, requestModel.Type);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
