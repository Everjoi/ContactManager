using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager
{
    public class ContactManagerDbContext : DbContext
    {
        public ContactManagerDbContext() { }
        public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

    }
}
