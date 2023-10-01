using BookShopData.DAL;
using BookShopEntity.Entities;
using BookShopEntity.Entities.User;
using BookShopService.Services.Abstraction;
using BookShopService.Services.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopService.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IBasketContactService, BasketContactService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserService, UserService>();
            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireLowercase = true;
                option.Password.RequireDigit = true;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 3;
                option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";
                option.User.RequireUniqueEmail = true;
                option.Lockout.AllowedForNewUsers = true;

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>().AddErrorDescriber<CustomIdentityValidator>();

            //services.AddControllersWithViews().AddFluentValidation(opt =>
            //{
            //    opt.DisableDataAnnotationsValidation = true;
            //    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("az");
            //});
            return services;
        }
    }
}
