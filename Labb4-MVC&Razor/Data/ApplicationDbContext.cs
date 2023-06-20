using Labb4_MVC_Razor.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Labb4_MVC_Razor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookList> BookLists { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Don Quijote",
                    Description = "The journey of a madman",
                    Author = "Miguel Cervantes"
                },
                new Book
                {
                    BookId = 2,
                    Title = "Robinson Crusoe",
                    Description = "The tale of a shipwrecked man",
                    Author = "Daniel Defoe"
                },
                new Book
                {
                    BookId = 3,
                    Title = "Harry Potter",
                    Description = "The tale of young wizard",
                    Author = "J.K Rowling"
                },
                new Book
                {
                    BookId = 4,
                    Title = "The Lord of the Rings",
                    Description = "Charachters come together to fight evil",
                    Author = "J.R.R Tolkien"
                },
                new Book
                {
                    BookId = 5,
                    Title = "War and Peace",
                    Description = "We follow aristocratic families in Russia during the Napoleonic wars",
                    Author = "Leo Tolstoy"
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Firstname = "Jon",
                    Lastname = "Westman",
                    Address = "Kyrklägdan 18",
                    Email = "jon@mail.com",
                    Phone = "0701234567"
                },
                new Customer
                {
                    CustomerId = 2,
                    Firstname = "Malin",
                    Lastname = "Eriksson",
                    Address = "Kyrklägdan 18",
                    Email = "malin@mail.com",
                    Phone = "0701234568"
                },
                new Customer
                {
                    CustomerId = 3,
                    Firstname = "Sven",
                    Lastname = "Svensson",
                    Address = "Svenssonvägen 1",
                    Email = "sven@mail.com",
                    Phone = "0701234569"
                },
                new Customer
                {
                    CustomerId = 4,
                    Firstname = "Åke",
                    Lastname = "Persson",
                    Address = "Perssongatan 1",
                    Email = "ake@mail.com",
                    Phone = "0701234560"
                },
                new Customer
                {
                    CustomerId = 5,
                    Firstname = "Lisa",
                    Lastname = "Nilsson",
                    Address = "Kyrkogatan 1",
                    Email = "lisa@mail.com",
                    Phone = "0701234561"
                });
        }
    }
}
