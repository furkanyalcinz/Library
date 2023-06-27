using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        private IUserService _userService;

        public BookController(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        [HttpGet("GetAllBooks"), Authorize]
        public IActionResult GetAllBooks()
        {
            var result = _bookService.GetAll();
            return Ok(result);
        }
        [HttpPost("Reserve <BookId>"), Authorize]
        public IActionResult ReserveBook(int BookId, [FromBody] DateTime returnDate)
        {
            var headers = Request.Headers.Authorization.ToString().Remove(0, 7);
            var res = JwtDecoder.JwtDecode(headers).Claims.ToList();
            var email = res[1].Value;
            var userId = _userService.GetUserIdByEmail(email);
            return Ok(_bookService.Reserve(BookId, userId, returnDate));
        }
    }
}
