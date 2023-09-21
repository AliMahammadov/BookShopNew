using System.ComponentModel.DataAnnotations;

namespace BookShopViewModel.Entites
{
    public class ReviewVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Comment { get; set; }

        public int BookId { get; set; }
    }
}
