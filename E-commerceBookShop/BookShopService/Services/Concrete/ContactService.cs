using BookShopData.UnitOfWorks;
using BookShopEntity.Entities;
using BookShopService.Services.Abstraction;
using BookShopViewModel.Entites;

namespace BookShopService.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddContactAsync(ContactVM contactVM)
        {
            if (contactVM is not null)
            {
                Contact contact = new Contact()
                {
                    Name = contactVM.Name,
                    Surname = contactVM.Surname,
                    Subject = contactVM.Subject,
                    Message = contactVM.Message,
                    Email = contactVM.Email,
                    CreateAt = DateTime.Now
                };

                await unitOfWork.GetRepository<Contact>().AddAsync(contact);
                await unitOfWork.SaveChangeAsync();
            }

        }

        public async Task<ICollection<Contact>> GetAllContactsAsync()
        {
            return await unitOfWork.GetRepository<Contact>().GetAllAsync();
        }
    }
}
