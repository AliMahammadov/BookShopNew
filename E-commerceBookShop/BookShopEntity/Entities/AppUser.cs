using Microsoft.AspNetCore.Identity;
namespace BookShopEntity.Entities.User
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? ConfirmCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
