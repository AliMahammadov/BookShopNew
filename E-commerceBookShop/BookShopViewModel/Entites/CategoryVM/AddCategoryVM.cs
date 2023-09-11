using BookShopEntity.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookShopViewModel.Entites.CategoryVM
{
    public class AddCategoryVM
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Book>? GetBooks { get; set; }
    }
}
