using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using webapi.data;
using webapi.business.Services;
using webapi.data.Repositories;

namespace webapi.root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void injectDependencies(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(opts => opts.UseInMemoryDatabase("database"));
            services.AddScoped<DatabaseContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}