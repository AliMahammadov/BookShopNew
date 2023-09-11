using BookShopService.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View();
    }
}
