using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.core.Models;

namespace webapi.business.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Task<Author> GetAuthorByName(string firstName);
        void InsertAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Guid id);
    }
}
