
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
            string conn = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ProjectDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
