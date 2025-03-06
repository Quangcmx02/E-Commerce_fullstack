using AsmC5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AsmC5.Context
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboFoodItem> ComboFoodItems { get; set; }
        public DbSet<ComboFoodItemDetail> ComboFoodItemDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Cart and User relationship
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<Cart>(c => c.UserID)
                .OnDelete(DeleteBehavior.NoAction);


            // CartItem and FoodItem relationship
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.FoodItem)
                .WithMany()
                .HasForeignKey(ci => ci.FoodItemID)
                .OnDelete(DeleteBehavior.NoAction);
            ;

            // CartItem and Combo relationship
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Combo)
                .WithMany(c => c.CartItems)  // Chỉ định rõ navigation property
                .HasForeignKey(ci => ci.ComboID)
                .OnDelete(DeleteBehavior.NoAction);





            // ComboFoodItem and FoodItem relationship
            modelBuilder.Entity<ComboFoodItem>()
                .HasOne(cfi => cfi.FoodItem)
                .WithMany()
                .HasForeignKey(cfi => cfi.FoodItemID)
                .OnDelete(DeleteBehavior.NoAction);


            // Order and User relationship
            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.User)
            //    .WithMany()
            //    .HasForeignKey(o => o.UserID);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa user nếu có Order

            // OrderDetail and FoodItem relationship
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.FoodItem)
                .WithMany()
                .HasForeignKey(od => od.FoodItemID)
                .OnDelete(DeleteBehavior.NoAction);

            // OrderDetail and Combo relationship
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Combo)
                .WithMany()
                .HasForeignKey(od => od.ComboID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    
}
