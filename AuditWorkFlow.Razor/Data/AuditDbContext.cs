using AuditWorkFlow.Razor.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuditWorkFlow.Razor.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(a => a.Status)
                .HasDefaultValue("1");

            modelBuilder.Entity<Customer>()
                .HasData(new List<Customer>()
                            {
                                new Customer {
                                    Id = Guid.Parse("33bbc9f2-869d-47a7-8d90-d2b533b60f48"),
                                    FirstName = "Pradeep",
                                    LastName = "Gandham",
                                    Email = "prad@gmail.com",
                                    CountryCode = "+91",
                                    PhoneNumber = "9292929292",
                                    PanNumber = "testpan001",
                                    Status = 1
                                },
                                    new Customer {
                                    Id = Guid.Parse("f51fdf1b-aee9-441f-9ed5-1877ac407cc9"),
                                    FirstName = "Praveen",
                                    LastName = "Gandham",
                                    Email = "prav@gmail.com",
                                    CountryCode = "+91",
                                    PhoneNumber = "898989898",
                                    PanNumber = "testpan002",
                                    Status = 1
                                }
                });

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
