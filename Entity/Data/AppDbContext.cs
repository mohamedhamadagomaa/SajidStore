using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Entity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<ItemTypes> ItemTypes { get; set; }
        public DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MOHAMMAD-HAMADA\\SQLEXPRESS;Database=SajidDB;Integrated Security=True;User Id=sa;Password=78951;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
         .HasOne(i => i.ItemType)
         .WithMany(it => it.Items)
         .HasForeignKey(i => i.TypeID)
         .OnDelete(DeleteBehavior.Cascade);

           

            //    new Item
            //    {
            //        ID = 1,
            //        ItemName = "Laptop",
            //        ItemNo = 1001,
            //        Quantity = 10,
            //        Price = 1500.00m
            //    }
            //    );
        }

    }
}
