using System.ComponentModel.DataAnnotations;

namespace BookShopViewModel.Entites
{
    public class ContactVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
