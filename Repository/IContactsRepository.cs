using ContactsAdm.Models;

namespace ContactsAdm.Repository
{
    public interface IContactsRepository
    {
        Task<ContactModel> GetById(Guid id);
        Task<IEnumerable<ContactModel>> ListAll();
        Task<ContactModel> Create(ContactModel contact);
        Task<ContactModel> Update(ContactModel contact);
        Task<ContactModel> Delete(ContactModel contact);
    }
}
