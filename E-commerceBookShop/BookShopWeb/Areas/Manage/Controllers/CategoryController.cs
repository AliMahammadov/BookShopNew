using BookShopService.Services.Abstraction;
using BookShopService.Services.Concrete;
using BookShopViewModel.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin,Admin")]
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
        public async Task<IActionResult> Add(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return View();
            await categoryService.AddCategoryAsync(categoryVM);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
                var category = await categoryService.EditCategoryAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Fill every input";
                return View();
            }
            await categoryService.UpdateCategoryAsync(id, categoryVM);
            return RedirectToAction("Index");
        }
    }
}
