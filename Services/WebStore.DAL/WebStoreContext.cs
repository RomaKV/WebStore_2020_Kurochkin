using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Services.WebStore.DAL
{
    public class WebStoreContext : IdentityDbContext<User>
    {
        public WebStoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
