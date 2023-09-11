using System.ComponentModel.DataAnnotations;

namespace BookShopViewModel.Entites.ContactVM
{
    public class CreateContactVM
    {
        [Required, MaxLength(15), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(20), MinLength(5)]
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Subject { get; set; }
        [Required,MaxLength(150)]
        public string Message { get; set; }
    }
}
