using BookShopEntity.Entities;
using BookShopEntity.Entities.User;
using BookShopEntity.Entity;

namespace BookShopViewModel.Entites.Home
{
    public class HomeVM
    {
        public Book Book { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Category> Categories{ get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
        public BasketContactVM BasketContactVM { get; set; }
        public ICollection<BasketContact> BasketContacts { get; set; }

    }
}
