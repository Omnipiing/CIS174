using Microsoft.EntityFrameworkCore;

namespace MultiPageWebAppElliott.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact>? Contacts { get; set; }

        //public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactID = 2,
                    ContactName = "Tony Robinson",
                    PhoneNumber = "5552783000",
                    Address = "123 Keats Ave, Tempe, AZ 85209",
                    Notes = "D&D DM"
                },
                new Contact
                {
                    ContactID = 3,
                    ContactName = "Derek Ebel",
                    PhoneNumber = "5558675309",
                    Address = "9876 Boss Dr, Huxley, IA 50023",
                    Notes = "Team Leader"
                },
                new Contact
                {
                    ContactID = 4,
                    ContactName = "Timothy Cross",
                    PhoneNumber = "5551234567",
                    Address = "666 13th St, Boston, MA 10015",
                    Notes = "Brother-in-arms"
                }
                ) ;
        }
    }
}
