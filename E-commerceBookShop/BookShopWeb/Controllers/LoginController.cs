using BookShopDto.Dtos.AppUserDtos;
using BookShopEntity.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginDto loginDto)
        {

            if(loginDto.UserName is null)
            {
                ModelState.AddModelError("", "Ad sahəsi tələb olunur.");
                return View();
            }
            if (loginDto.Password is null)
            {
                ModelState.AddModelError("", "Şifrə sahəsi tələb olunur.");
                return View();
            }
            
            var result = await signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, loginDto.RememberMe, true);

            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(loginDto.UserName);
                if (user.EmailConfirmed is true)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
