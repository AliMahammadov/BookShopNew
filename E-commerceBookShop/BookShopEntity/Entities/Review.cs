using BookShopCore.Entities;
using BookShopEntity.Entity;

namespace BookShopEntity.Entities
{
    public class Review:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public int BookId { get; set; }
        public Book Book{ get; set; }
    }
}
