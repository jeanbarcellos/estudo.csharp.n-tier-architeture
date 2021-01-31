using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using webapi.core.Models;
using webapi.business.Services;

namespace webapi.api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Book> GetAllBooks() =>
            _bookService.GetAllBooks();

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void InsertBook([FromBody] Book book) =>
            _bookService.InsertBook(book);

        [HttpGet]
        [Route("{id:guid}")]
        public Book GetBookById(Guid id) =>
            _bookService.GetBookById(id);

        [HttpPut]
        [Route("{id:guid}")]
        [AllowAnonymous]
        public void UpdateBook([FromBody] Book book) =>
            _bookService.UpdateBook(book);

        [HttpDelete]
        [Route("{id:guid}")]
        [AllowAnonymous]
        public void DeleteBook(Guid id) =>
            _bookService.DeleteBook(id);
    }
}