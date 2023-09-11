using BookShopEntity.Entities;
using BookShopViewModel.Entites.CategoryVM;

namespace BookShopService.Services.Abstraction
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(AddCategoryVM categoryVM);
        Task<ICollection<Category>> GetAllCategoryAsync();
    }
}
