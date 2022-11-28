using BussinesLayer.Interface;
using BussinesLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost("AddBook")]
        public IActionResult addBook(BookModel book)
        {
            try
            {
                var result = bookBL.addBook(book);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Added Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to add book" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = bookBL.GetAllBooks();
                if (result != null)
                {
                    return Ok(new { data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Faild to get all Book" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("GetBookbyID")]
        public IActionResult GetBookByID(int bookId)
        {
            try
            {
                var result = bookBL.GetBookByID(bookId);
                if (result != null)
                {
                    return Ok(new { data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Faild to get all Book" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    
}
