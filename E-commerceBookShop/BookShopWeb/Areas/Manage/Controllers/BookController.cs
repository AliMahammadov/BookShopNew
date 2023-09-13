using BookShopData.DAL;
using BookShopEntity.Entities;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin,Admin")]
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
            if (!ModelState.IsValid) return BadRequest();
            await bookService.DeleteBookAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!ModelState.IsValid) return View();
            ViewBag.Categories = new SelectList(appDbContext.Categories, nameof(Category.Id), nameof(Category.Name));
            var book = await bookService.GetBookEditAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, BookVM bookVM)
        {
            if (!ModelState.IsValid || bookVM.Image is null)
            {
                ViewBag.Categories = new SelectList(appDbContext.Categories, nameof(Category.Id), nameof(Category.Name));
                var book = await bookService.GetBookEditAsync(id);
                ViewBag.Message = "Fill every input";
                return View(book);
            }
            await bookService.UpdateBookAsync(id, bookVM);
            return RedirectToAction("Index");
        }
    }
}
