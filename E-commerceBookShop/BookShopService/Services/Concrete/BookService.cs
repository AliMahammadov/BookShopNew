using BookShopData.DAL;
using BookShopData.UnitOfWorks;
using BookShopEntity.Entity;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookShopService.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment environment;
        private readonly AppDbContext appDbContext;

        public BookService(IUnitOfWork unitOfWork, IHostingEnvironment environment, AppDbContext appDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
            this.appDbContext = appDbContext;
        }

        public async Task AddBookAsync(BookVM bookVM)
        {
            IFormFile file = bookVM.Image;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "manage", "img", "book", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();

            Book book = new Book
            {
                Name = bookVM.Name,
                Language = bookVM.Language,
                PageCount = bookVM.PageCount,
                SKU = bookVM.SKU,
                Author = bookVM.Author,
                Publisher = bookVM.Publisher,
                Price = bookVM.Price,
                ShortDescription = bookVM.ShortDescription,
                LongDescription = bookVM.LongDescription,
                Instagram = bookVM.Instagram,
                Facebook = bookVM.Facebook,
                ImageUrl = fileName,
                CategoryId = bookVM.CategoryId,
                CreateAt = DateTime.Now
            };

            await unitOfWork.GetRepository<Book>().AddAsync(book);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteBookAsync(int? id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            string filePath = Path.Combine(environment.WebRootPath, "manage", "img", "book", book.ImageUrl);
            File.Delete(filePath);
            await unitOfWork.GetRepository<Book>().DeleteAsync(book);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            return await unitOfWork.GetRepository<Book>().GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int? id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (book == null)
                return book;

            return book;
        }

        public async Task<ICollection<Book>> GetBookForAsCategory(int? id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            return await appDbContext.Books.Where(b => b.Category == book.Category).ToListAsync();
        }

        public async Task<Book> GetBookIncludeAsync(int? id)
        {
            return await appDbContext.Books.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
