using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites.AdminVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBusinessWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin,Admin")]
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        private readonly IUserService userService;

        public HomeController(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            CombinedAdminVM adminVM = new CombinedAdminVM
            {
                Users = await userService.GetAllUsersAsync(),
                Books = await bookService.GetAllBooksAsync(),
            };

            return View(adminVM);
        }
    }
}
