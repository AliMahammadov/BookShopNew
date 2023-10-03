using BookShopData.DAL;
using BookShopData.UnitOfWorks;
using BookShopEntity.Entity;
using BookShopService.Services.Abstraction;
using BookShopViewModel;
using BookShopViewModel.Entites;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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

        public async Task<BookVM> GetBookEditAsync(int? id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);

            BookVM vm = new BookVM()
            {
                Name = book.Name,
                Language = book.Language,
                PageCount = book.PageCount,
                SKU = book.SKU,
                Author = book.Author,
                Publisher = book.Publisher,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                ShortDescription = book.ShortDescription,
                LongDescription = book.LongDescription,
                Facebook = book.Facebook,
                Instagram = book.Instagram,
                CategoryId = book.CategoryId
            };

            return vm;
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

        public async Task<Book> GetBookViewAsync(int? id)
        {
            return await appDbContext.Books.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<PaginationVM<Book>> PaginationForBookAsync(int page)
        {
            PaginationVM<Book> paginationVM = new PaginationVM<Book>();
            paginationVM.MaxPageCount = (int)Math.Ceiling((decimal)appDbContext.Books.Count() / 20);
            paginationVM.CurrentPage = page;
            if (paginationVM.CurrentPage > paginationVM.MaxPageCount || page < 1) return null;
            paginationVM.Items = await appDbContext.Books.Skip((page - 1) * 20).Take(20).ToListAsync();

            return paginationVM;
        }

        public async Task UpdateBookAsync(int? id, BookVM bookVM)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);

            if (bookVM is not null || book is not null)
            {
                IFormFile file = bookVM.Image;
                string fileName = Guid.NewGuid().ToString() + file.FileName;
                using var stream = new FileStream(Path.Combine(environment.WebRootPath, "manage", "img", "book", fileName), FileMode.Create);
                await file.CopyToAsync(stream);
                await stream.FlushAsync();

                book.Name = bookVM.Name;
                book.Language = bookVM.Language;
                book.PageCount = bookVM.PageCount;
                book.SKU = bookVM.SKU;
                book.Author = bookVM.Author;
                book.Publisher = bookVM.Publisher;
                book.ImageUrl = fileName;
                book.Price = bookVM.Price;
                book.ShortDescription = bookVM.ShortDescription;
                book.LongDescription = bookVM.LongDescription;
                book.Facebook = bookVM.Facebook;
                book.Instagram = bookVM.Instagram;
                book.CategoryId = bookVM.CategoryId;
                book.UpdateAt = DateTime.Now;

                await unitOfWork.GetRepository<Book>().UpdateAsync(book);
                await unitOfWork.SaveChangeAsync();
            }
        }
    }
}
