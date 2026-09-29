using Microsoft.EntityFrameworkCore;
using WeddingAppMVC.Models;

namespace WeddingAppMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<WeddingInfo> WeddingInfos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "The ceremony", StartTime = new DateTime(2027, 6, 20, 15, 0, 0), Location = "Rosewood Estate", Address = "18 Willow Lane, Hampshire, England", Description = "The ceremony will take place outdoors in the estate's beautiful garden, surrounded by flowers and old oak trees. Guests are kindly asked to arrive at least 30 minutes before the ceremony begins." },
                new Event { Id = 2, Title = "The reception", StartTime = new DateTime(2027, 6, 20, 16, 30, 0), Location = "Rosewood Estate", Address = "18 Willow Lane, Hampshire, England", Description = "Following the ceremony, we will continue the celebrations with drinks, dinner, speeches, and dancing in the main hall at Rosewood Estate." },
                new Event { Id = 3, Title = "Dinner", StartTime = new DateTime(2027, 6, 20, 18, 0, 0), Location = "Rosewood Estate", Address = "18 Willow Lane, Hampshire, England", Description = "A three-course dinner will be served in the main hall. Please let us know about any allergies or dietary requirements in your RSVP message." },
                new Event { Id = 4, Title = "First dance", StartTime = new DateTime(2027, 6, 20, 20, 30, 0), Location = "Rosewood Estate", Address = "18 Willow Lane, Hampshire, England", Description = "After dinner, the newlyweds will share their first dance. The dance floor then opens to all guests, and the celebrations continue into the night." }
            );

            modelBuilder.Entity<Guest>().HasData(
                // Only registered guests, no RSVP
                new Guest { Id = 1, FirstName = "Emma", LastName = "Andersson", Email = "emma.andersson@example.com", PhoneNumber = "070 123 45 67", RegistrationDate = new DateTime(2026, 9, 1, 10, 15, 0), HasResponded = false },
                new Guest { Id = 2, FirstName = "Oscar", LastName = "Lindqvist", Email = "oscar.lindqvist@example.com", PhoneNumber = "073 234 56 78", RegistrationDate = new DateTime(2026, 9, 2, 14, 30, 0), HasResponded = false },
                new Guest { Id = 3, FirstName = "Sara", LastName = "Berg", Email = "sara.berg@example.com", PhoneNumber = "076 345 67 89", RegistrationDate = new DateTime(2026, 9, 3, 9, 0, 0), HasResponded = false },

                // Guests who have answered on RSVP
                new Guest { Id = 4, FirstName = "Johan", LastName = "Nilsson", Email = "johan.nilsson@example.com", PhoneNumber = "070 456 78 90", Attendance = true, NumberOfAttendants = 2, Message = "Looking forward to it!", RegistrationDate = new DateTime(2026, 9, 4, 18, 45, 0), HasResponded = true },
                new Guest { Id = 5, FirstName = "Lina", LastName = "Karlsson", Email = "lina.karlsson@example.com", PhoneNumber = "072 567 89 01", Attendance = true, NumberOfAttendants = 1, Message = "I'm vegetarian.", RegistrationDate = new DateTime(2026, 9, 5, 12, 10, 0), HasResponded = true },
                new Guest { Id = 6, FirstName = "Erik", LastName = "Svensson", Email = "erik.svensson@example.com", PhoneNumber = "070 678 90 12", Attendance = true, NumberOfAttendants = 4, Message = "Bringing the kids, hope that's fine.", RegistrationDate = new DateTime(2026, 9, 6, 20, 0, 0), HasResponded = true },
                new Guest { Id = 7, FirstName = "Maja", LastName = "Holm", Email = "maja.holm@example.com", PhoneNumber = "073 789 01 23", Attendance = false, NumberOfAttendants = 1, Message = "Sadly can't make it, congratulations!", RegistrationDate = new DateTime(2026, 9, 7, 8, 20, 0), HasResponded = true }
            );

            modelBuilder.Entity<WeddingInfo>().HasData(
                new WeddingInfo
                {
                    Id = 1,
                    Title = "Alice & Bob's forever begins",
                    WelcomeMessage = "Welcome to our wedding!",
                    Description = "We’re so happy to have you here! Welcome to the official wedding website of Alice & Bob. ",
                    Contact = "alice.bob@example.com",
                    WebsiteDescription = "Here you can find information about the wedding and RSVP. If you need to contact us, contact our email below.",
                    ClosingMessage = "We can't wait to celebrate with you!"
                });
        }
    }
}
