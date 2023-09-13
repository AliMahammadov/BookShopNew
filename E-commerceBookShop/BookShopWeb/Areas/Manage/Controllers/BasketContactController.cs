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
 
        public async Task<IActionResult> İndex()
        {
            return View(await basketContactService.GetAllContactsAsync());
        }
    }
}
