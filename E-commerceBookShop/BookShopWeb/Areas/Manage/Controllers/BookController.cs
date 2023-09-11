using BookShopData.DAL;
using BookShopEntity.Entities;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly AppDbContext appDbContext;

        public BookController(IBookService bookService, AppDbContext appDbContext)
        {
            this.bookService = bookService;
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await bookService.GetAllBooksAsync());

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = new SelectList(appDbContext.Categories, nameof(Category.Id), nameof(Category.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookVM bookVM)
        {
            if (!ModelState.IsValid) 
            { ViewBag.Categories = new SelectList(appDbContext.Categories, nameof(Category.Id), nameof(Category.Name)); return View(); }
            await bookService.AddBookAsync(bookVM);
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!ModelState.IsValid) return View();
            await bookService.DeleteBookAsync(id);
            return RedirectToAction("Index");
        }
    }
}
