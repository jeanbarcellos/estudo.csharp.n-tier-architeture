using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.core.Models;
using webapi.data.Repositories;

namespace webapi.business.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Author> GetAllAuthors() => _unitOfWork.AuthorRepository.GetAll();

        public Task<Author> GetAuthorByName(string firstName) => _unitOfWork.AuthorRepository.GetByName(firstName);

        public void InsertAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Insert(author);
            _unitOfWork.Commit();
        }

        public void UpdateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.Commit();
        }

        public void DeleteAuthor(Guid id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
