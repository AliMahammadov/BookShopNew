using BookShopData.UnitOfWorks;
using BookShopEntity.Entities;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites.CategoryVM;

namespace BookShopService.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddCategoryAsync(AddCategoryVM categoryVM)
        {
            Category category = new Category()
            {
                Name = categoryVM.Name,
                CreateAt = DateTime.Now
            };
            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveChangeAsync();

        }

        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            return await unitOfWork.GetRepository<Category>().GetAllAsync();
        }
    }
}
