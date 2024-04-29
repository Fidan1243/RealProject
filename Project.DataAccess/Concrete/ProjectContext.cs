
using Microsoft.EntityFrameworkCore;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Concrete
{
    public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = @"Server=tcp:ecommercealtos.database.windows.net,1433;Initial Catalog=ProjectDb1;Persist Security Info=False;User ID=adminecommerce;Password=29u2ev66.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(conn);
        }


        public DbSet<Model> Models { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ComboComment> ComboComments { get; set; }
        public DbSet<ComboLike> ComboLikes { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }

    }
}
