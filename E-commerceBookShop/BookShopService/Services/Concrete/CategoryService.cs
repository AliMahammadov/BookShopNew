using BookShopData.UnitOfWorks;
using BookShopEntity.Entities;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites;

namespace BookShopService.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddCategoryAsync(CategoryVM categoryVM)
        {
            Category category = new Category()
            {
                Name = categoryVM.Name,
                CreateAt = DateTime.Now
            };
            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveChangeAsync();

        }

        public async Task<CategoryVM> EditCategoryAsync(int? id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            CategoryVM vm = new CategoryVM() { Name = category.Name };
            return vm;
        }

        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            return await unitOfWork.GetRepository<Category>().GetAllAsync();
        }

        public async Task UpdateCategoryAsync(int? id, CategoryVM categoryVM)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            
            if(category is not null)
            {
                category.Name = categoryVM.Name;
                category.UpdateAt = DateTime.Now;

                await unitOfWork.GetRepository<Category>().UpdateAsync(category);
                await unitOfWork.SaveChangeAsync();
            }
        }
    }
}
