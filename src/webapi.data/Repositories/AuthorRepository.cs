using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.core.Models;

namespace webapi.data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DatabaseContext context) : base(context) { }

        public Task<Author> GetByName(string name)
        {
            return FindByCondition(author => author.Name == name);
        }

    }

}
