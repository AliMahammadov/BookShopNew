using System.ComponentModel.DataAnnotations;

namespace BookShopViewModel.Entites.AccountVM
{
    public class RegisterVM
    {
        [Required, MaxLength(15)]
        public string Name { get; set; }
        [Required, MaxLength(15)]
        public string SurName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(15)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
