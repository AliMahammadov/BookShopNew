using BookShopEntity.Entities;
using Microsoft.AspNetCore.Http;

namespace BookShopViewModel.Entites
{
    public class BookVM
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public ushort PageCount { get; set; }
        public string SKU { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl{ get; set; }
        public float Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
