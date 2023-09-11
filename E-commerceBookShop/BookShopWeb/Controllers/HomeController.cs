using BookShopEntity.Entity;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites.Home;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index() => View(await bookService.GetAllBooksAsync());

        public async Task<IActionResult> Detail(int? id)
        {
            Book book = await bookService.GetBookIncludeAsync(id);
            if (book is not null)
            {
                HomeVM homeVM = new HomeVM()
                {
                    Book = book,
                    Books = await bookService.GetBookForAsCategory(id),
                };

                return View(homeVM);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
