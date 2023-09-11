using BookShopCore.Entities;
using BookShopEntity.Entities;

namespace BookShopEntity.Entity
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public ushort PageCount { get; set; }
        public string SKU { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


        public ICollection<Review>? Reviews { get; set; }



}

}
