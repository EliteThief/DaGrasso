using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore;
using DaGrasso.Data.Models;
using DaGrasso.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DaGrasso
{
    public class DagrassoContext : IdentityDbContext<ApplicationUser>
    {
        public DagrassoContext(DbContextOptions<DagrassoContext> options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PizzaTopping>()
                .HasKey(pt => new {pt.PizzaId, pt.ToppingId});

            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Pizza)
                .WithMany(p => p.Toppings)
                .HasForeignKey(pt => pt.PizzaId);
            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Topping)
                .WithMany(t => t.Pizzas)
                .HasForeignKey(pt => pt.ToppingId);
            

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
        }
    }
}
