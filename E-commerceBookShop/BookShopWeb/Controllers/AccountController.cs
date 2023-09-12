using BookShopEntity.Entities.User;
using BookShopViewModel.Entites.AccountVM;
using BookShopViewModel.Entites.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class AccountController : Controller
    {
        SignInManager<AppUser> signInManager;
        UserManager<AppUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid) return View();
            AppUser user = await userManager.FindByNameAsync(loginVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("Username","Login or Password is wrong");
                return View();
            }
            var result = await signInManager.PasswordSignInAsync(user, loginVM.Password,loginVM.RememberMe,true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password", "Login or Password is wrong");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await userManager.FindByNameAsync(registerVM.UserName);
            if (user != null)
            {
                ModelState.AddModelError("Username", "This User already exists");
                return View();
            }
            user = new AppUser
            {
                Name = registerVM.UserName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
            };
            IdentityResult result = await userManager.CreateAsync(user,registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            //await userManager.AddToRoleAsync(user, "Admin");
            //await signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> AddRoles()
        {
            await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
           
            return View();

        }
        public async Task<IActionResult> Test()
        {
            var user = await userManager.FindByNameAsync("Ruslan");
            await userManager.AddToRoleAsync(user, "Admin");
            return View();
        }

    }
}
