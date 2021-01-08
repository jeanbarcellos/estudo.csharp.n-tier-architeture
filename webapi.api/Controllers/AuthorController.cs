using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.core.Models;
using webapi.data.Repositories;

namespace webapi.Controllers
{
    [ApiController]
    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("")]
        public IEnumerable<Author> GetAllAuthots() => _authorRepository.GetAll();

        [HttpPost("")]
        [AllowAnonymous]
        public void InsertAuthor([FromBody] Author author) => _authorRepository.Insert(author);

        [HttpGet("{name}")]
        public Task<Author> GetAuthorByName(String name) => _authorRepository.GetByName(name);

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public void UpdateAuthor([FromBody] Author author) => _authorRepository.Update(author);

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public void DeleteAuthor(Guid id) => _authorRepository.Delete(id);
    }
}