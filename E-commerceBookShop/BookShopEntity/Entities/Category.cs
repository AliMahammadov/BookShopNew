using BookShopCore.Entities;
using BookShopEntity.Entity;

namespace BookShopEntity.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book>? GetBooks { get; set; }
    }
}
