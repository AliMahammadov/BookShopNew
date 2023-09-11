using BookShopService.Services.Abstraction;
using BookShopService.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopService.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
