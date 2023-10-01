using BookShopEntity.Entities.User;
using BookShopViewModel.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = TempData["Mail"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailVM confirmMail)
        {
            var user = await userManager.FindByEmailAsync(confirmMail.Email);
            if(user.ConfirmCode == confirmMail.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index), "Home");
            }
            return View();
        }
    }
}
