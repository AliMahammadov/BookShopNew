using BookShopEntity.Entities.User;
using BookShopEntity.Entity;

namespace BookShopViewModel.Entites.AdminVM
{
    public class CombinedAdminVM
    {
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
