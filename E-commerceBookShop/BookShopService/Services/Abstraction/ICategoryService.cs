using BookShopEntity.Entities;
using BookShopViewModel.Entites;

namespace BookShopService.Services.Abstraction
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryVM categoryVM);
        Task<ICollection<Category>> GetAllCategoryAsync();
        Task<CategoryVM> EditCategoryAsync(int? id);
        Task UpdateCategoryAsync(int? id, CategoryVM categoryVM);
    }
}
