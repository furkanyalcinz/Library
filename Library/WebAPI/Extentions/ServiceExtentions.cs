using Business.Abstract;
using Business.Concrete;
using Business.Validator;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Extentions
{
    public static class ServiceExtentions
    {
        public static void AddServiceExtentions(this IServiceCollection Services) 
        {
            Services.AddDbContext<LibraryDbContext>();
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<IBookRepository, BookRepository>();
     
            Services.AddScoped<IBorrowedRepository, BorrowedRepository>();
            Services.AddScoped<IUserValidator, UserValidator>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IBookService, BookService>();
        }
    }
}
