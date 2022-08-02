using Autumn.BookManagement.Repositories;
using Autumn.BookManagement.Repositories.Interfaces;
using Autumn.BookManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autumn.BookManagement.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterComponentServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options
               .UseLazyLoadingProxies()
               .UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            // DI register
            services
                .AddTransient<IBookService, BookService>()
                .AddTransient<IBookRepository, BookRepository>()
                .AddTransient<IUserBookService, UserBookService>()
                .AddTransient<IUserBookRepository, UserBookRepository>()
                ;

            return services;
        }
    }
}