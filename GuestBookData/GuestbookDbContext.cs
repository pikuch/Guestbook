using GuestbookData.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace GuestbookData
{
    public class GuestbookDbContext : DbContext
    {
        public DbSet<GuestbookEntry> GuestbookEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestbookEntry>().HasData(
                new GuestbookEntry
                {
                    Id = 1,
                    Name = "Adam",
                    Email = "adam@gmail.com",
                    Comment = "Awesome site bro, but I don't like the background that much.",
                    Timestamp = DateTime.Today.AddHours(-1),
                },
                new GuestbookEntry
                {
                    Id = 2,
                    Name = "Bernard",
                    Email = "bernard@yahoo.com",
                    Comment = "Umm... where do I submit the post?",
                    Timestamp = DateTime.Today.AddHours(-2),
                },
                new GuestbookEntry
                {
                    Id = 3,
                    Name = "Cecilia",
                    Email = "cecilia@microsoft.com",
                    Comment = "We work so hard to deliver all these awesome software and people use it to make stuff like this -_-",
                    Timestamp = DateTime.Today.AddHours(-3),
                },
                new GuestbookEntry
                {
                    Id = 4,
                    Name = "Dick",
                    Email = "dick@gmail.com",
                    Comment = "I was here and found your interface inadequate.",
                    Timestamp = DateTime.Today.AddHours(-4),
                },
                new GuestbookEntry
                {
                    Id = 5,
                    Name = "Ernest",
                    Email = "ernest@aol.com",
                    Comment = "Lovely site, keep it going!",
                    Timestamp = DateTime.Today.AddHours(-5),
                },
                new GuestbookEntry
                {
                    Id = 6,
                    Name = "Filip",
                    Email = "filip@gmail.com",
                    Comment = "ಠ_ಠ ಠ_ಠ ಠ_ಠ ಠ_ಠ ಠ_ಠ ಠ_ಠ",
                    Timestamp = DateTime.Today.AddHours(-3),
                }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDb;Database=GuestbookDB;Trusted_Connection=True;");
        }
    }
}
