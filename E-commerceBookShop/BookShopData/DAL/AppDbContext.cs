using BookShopEntity.Entities;
using BookShopEntity.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookShopData.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
