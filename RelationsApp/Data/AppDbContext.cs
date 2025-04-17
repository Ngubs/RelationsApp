using Microsoft.EntityFrameworkCore;
using RelationsApp.Models;

namespace RelationsApp.Data
{
    /*
     * I have also used a Primary Constructor in this class as well.
     * Go through the StudentController class to see the 'definition' thereof.
     */
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        /*
         * I have seeded data into both the 'Students' and the 'Addresses' tables 
         * note how these entities are linked with each other using Primary/Foreign
         * Key constraints to form a Relationship with One-to-One multiplicity
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    StudentId = 101,
                    Name = "Dumisane",
                    Surname = "Ngubs",
                    Email = "dngubane@iie.ac.za",
                    Phone = 155566,
                    AddressId = 1,
                },
                new Student()
                {
                    StudentId = 102,
                    Name = "Benjie",
                    Surname = "Smith",
                    Email = "st2737377@vcconnect.ac.za",
                    Phone = 544588,
                    AddressId = 2
                });

            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    AddressId = 1,
                    UnitNumber = 1,
                    Street = "Benmore Road",
                    Suburb = "Parkmore",
                    Zip = 2025,
                    StudentId = 101
                },
                new Address()
                {
                    AddressId = 2,
                    UnitNumber = 25,
                    Street = "West Street",
                    Suburb = "Rivonia",
                    Zip = 2026,
                    StudentId = 102
                });
        }
    }
}
