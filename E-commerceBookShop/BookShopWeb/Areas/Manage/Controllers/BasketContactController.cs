using BookShopService.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Manage.Controllers
{
    [Area("Manage"), Authorize(Roles = "Super Admin,Admin")]
    public class BasketContactController : Controller
    {
        private readonly IBasketContactService basketContactService;

        public BasketContactController(IBasketContactService basketContactService)
        {
            this.basketContactService = basketContactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await basketContactService.GetAllContactsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> View(int? id)
        {
            if (id is not null)
                return View(await basketContactService.GetBasketContactViewAsync(id));
            return View();
        }

    }
}
