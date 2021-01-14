using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.core.Models;
using webapi.business.Services;

namespace webapi.api.Controllers
{
    [ApiController]
    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Author> GetAllAuthots() =>
            _authorService.GetAllAuthors();

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void InsertAuthor([FromBody] Author author) =>
            _authorService.InsertAuthor(author);

        [HttpGet]
        [Route("{name}")]
        public Task<Author> GetAuthorByName(String name) =>
            _authorService.GetAuthorByName(name);

        [HttpPut]
        [Route("{id:guid}")]
        [AllowAnonymous]
        public void UpdateAuthor([FromBody] Author author) =>
            _authorService.UpdateAuthor(author);

        [HttpDelete]
        [Route("{id:guid}")]
        [AllowAnonymous]
        public void DeleteAuthor(Guid id) =>
            _authorService.DeleteAuthor(id);
    }
}