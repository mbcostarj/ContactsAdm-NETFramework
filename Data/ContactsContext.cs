using ContactsAdm.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAdm.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
