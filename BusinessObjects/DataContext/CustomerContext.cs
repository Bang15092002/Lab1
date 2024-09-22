using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.DataContext
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("BangConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Customer>().HasData(
                     new Customer
                     {
                         Id = 1,
                         Username = "johnDoe",
                         Password = "Password123",
                         Fullname = "John Doe",
                         Gender = "Male",
                         Birthday = new DateOnly(1990, 1, 1),
                         Address = "123 Elm Street"
                     },
                    new Customer
                    {
                        Id = 2,
                        Username = "janeDoe",
                        Password = "Password456", 
                        Fullname = "Jane Doe",
                        Gender = "Female",
                        Birthday = new DateOnly(1992, 2, 15),
                        Address = "456 Oak Avenue"
                    },
                    new Customer
                    {
                        Id = 3,
                        Username = "johnDoe",
                        Password = "Password123",
                        Fullname = "John Doe",
                        Gender = "Male",
                        Birthday = new DateOnly(1990, 1, 1),
                        Address = "123 Elm Street"
                    },
                    new Customer
                    {
                        Id = 4,
                        Username = "johnDoe",
                        Password = "Password123",
                        Fullname = "John Doe",
                        Gender = "Male",
                        Birthday = new DateOnly(1990, 1, 1),
                        Address = "123 Elm Street"
                    },
                    new Customer
                    {
                        Id = 5,
                        Username = "johnDoe",
                        Password = "Password123",
                        Fullname = "John Doe",
                        Gender = "Male",
                        Birthday = new DateOnly(1990, 1, 1),
                        Address = "123 Elm Street"
                    },
                    new Customer
                    {
                        Id = 6,
                        Username = "johnDoe",
                        Password = "Password123",
                        Fullname = "John Doe",
                        Gender = "Male",
                        Birthday = new DateOnly(1990, 1, 1),
                        Address = "123 Elm Street"
                    }
            );
        }

    }
}