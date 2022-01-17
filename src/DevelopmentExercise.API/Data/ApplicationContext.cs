using DevelopmentExercise.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentExercise.API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new SeedData());
            modelBuilder.ApplyConfiguration<Discount>(new SeedData());
            modelBuilder.ApplyConfiguration<Order>(new SeedData());
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Discount> Discounts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
    }
}