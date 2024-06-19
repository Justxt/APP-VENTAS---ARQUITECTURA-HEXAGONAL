using AppSale.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Infrastructure.Data.Contexts
{
    public class ContextSale: DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<DetailSale> detailSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JUSS;Database=AppSale;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Configs.ProductConfig());
            modelBuilder.ApplyConfiguration(new Configs.SaleConfig());
            modelBuilder.ApplyConfiguration(new Configs.DetailSaleConfig());
        }
    }
}
