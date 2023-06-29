﻿using Business.Abstract;
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

        public BookController(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var result = _bookService.GetAll();
            return Ok(result);
        }
        [HttpPost("Reserve"), Authorize]
        public IActionResult ReserveBook([FromQuery]int BookId, [FromBody] DateTime returnDate)
        {
            var headers = Request.Headers.Authorization.ToString().Remove(0, 7);
            var res = JwtDecoder.JwtDecode(headers).Claims.ToList();
            var email = res[1].Value;
            var userId = _userService.GetUserIdByEmail(email);
            return Ok(_bookService.Reserve(BookId, userId, returnDate));
        }
        
        [HttpPost("AddBook"), Authorize("AdminOnly")]
        public IActionResult AddBook([FromForm]AddBookView model)
        {
            _bookService.AddBook(model);
            return Ok();
        }
        [HttpGet("GetPicture")]
        public IActionResult GetPictures([FromQuery]string imageName)
        {
            string imagePath = Directory.GetCurrentDirectory() + "/" + "Images" + "/" + imageName;
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            string contentType = "image/jpeg";
            var file = File(imageBytes, contentType);
            file.FileDownloadName = imageName;
            return Ok(file);
        }
    }
}
