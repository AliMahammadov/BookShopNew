using BookShopCore.Entities;
namespace BookShopEntity.Entities
{
    public class BasketContact:BaseEntity
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string? Message { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public float BookPrice { get; set; }
    }
}
