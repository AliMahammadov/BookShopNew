using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites.CategoryVM;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index() => View(await categoryService.GetAllCategoryAsync());

        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return View();
            await categoryService.AddCategoryAsync(categoryVM);
            return View();
        }
    }
}
