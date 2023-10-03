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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailVM confirmMail)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(confirmMail.Email);
                if (user is not null)
                {
                    try
                    {
                        if (user.ConfirmCode == int.Parse(confirmMail.ConfirmCode))
                        {
                            user.EmailConfirmed = true;
                            await userManager.UpdateAsync(user);
                            return RedirectToAction(nameof(Index), "Login");
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("", $"'{confirmMail.ConfirmCode}' yanlış kod, zəhmət olmasa Emailinizə göndərilməş kodu daxil edin.");
                        TempData["Mail"] = confirmMail.Email;
                        return View();
                    }
                }
            }

            TempData["Mail"] = confirmMail.Email;
            ModelState.AddModelError("", $"Kod sahəsi boş keçilə bilməz.");
            return View();
        }
    }
}
