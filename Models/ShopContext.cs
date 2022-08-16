using Microsoft.EntityFrameworkCore;


namespace CreditCardWebApi.Models
{
    public class ShopContext : DbContext 
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Customer>()
                .HasMany(c => c.CreditCards)
                .WithOne(x => x.Customer)
                .HasForeignKey(y => y.CustomerId);

            mb.Seed();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
