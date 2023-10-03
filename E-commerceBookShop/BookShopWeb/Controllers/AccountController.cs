using BookShopDto.Dtos.AppUserDtos;
using BookShopEntity.Entities.User;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace BookShopWeb.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View();
            AppUser appuseremail = await userManager.FindByEmailAsync(registerDto.Email);

            if(appuseremail is not null)
            {
                ModelState.AddModelError("", $"'{appuseremail.Email}' emaili artıq mövcuddur.");
                return View();
            }

            if(!(registerDto.Password.Equals(registerDto.ConfirmPassword)))
            {
                ModelState.AddModelError("", "Şifrələr bir biri ilə uyğunluq təşkil etmir");
                return View();
            }

            Random random = new Random();
            int code = random.Next(100000, 1000000);

            AppUser user = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.SurName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                ConfirmCode = code
            };

            IdentityResult result = await userManager.CreateAsync(user,registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Kitabal.biz.tr", "bookstore20232024@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Girişi həyata keçirmək üçün bu kodu yazın: " + code;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Kitabal.biz.tr təstiq kodu";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("bookstore20232024@gmail.com", "jojz ffgj jdrk cgub");
            client.Send(mimeMessage);
            client.Disconnect(true);

            TempData["Mail"] = registerDto.Email;

            return RedirectToAction(nameof(Index), "ConfirmMail");
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }


    }
}
