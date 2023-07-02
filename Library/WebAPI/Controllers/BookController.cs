using Business.Abstract;
using Business.Schema;
using Entity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        private IUserService _userService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, IUserService userService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                _logger.LogInformation("Books getting");
                var result = _bookService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("Reserve"), Authorize]
        public IActionResult ReserveBook([FromQuery]int BookId, [FromBody] DateTime returnDate)
        {
            try
            {
                _logger.LogInformation($"{BookId} will reserved");
                var headers = Request.Headers.Authorization.ToString().Remove(0, 7);
                var res = JwtDecoder.JwtDecode(headers).Claims.ToList();
                var email = res[1].Value;
                var userId = _userService.GetUserIdByEmail(email);
                _logger.LogInformation($"{BookId} reserved");
                return Ok(_bookService.Reserve(BookId, userId, returnDate));
                
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            
        }
        
        [HttpPost("AddBook"), Authorize("AdminOnly")]
        public IActionResult AddBook([FromForm]AddBookView model)
        {
            try
            {
                _logger.LogInformation("Book will added");
                _bookService.AddBook(model);
                _logger.LogInformation("Book added");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("GetPicture")]
        public IActionResult GetPictures([FromQuery]string imageName)
        {
            try
            {
                string imagePath = Directory.GetCurrentDirectory() + "/" + "Images" + "/" + imageName;
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                string contentType = "image/jpeg";
                var file = File(imageBytes, contentType);
                file.FileDownloadName = imageName;
                _logger.LogInformation($"Pictures: {imageName} returned");
                return Ok(file);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
