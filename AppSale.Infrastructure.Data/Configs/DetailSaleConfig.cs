using AppSale.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Infrastructure.Data.Configs
{
    public class DetailSaleConfig : IEntityTypeConfiguration<DetailSale>
    {
        public void Configure(EntityTypeBuilder<DetailSale> builder)
        {
            builder.ToTable("tblDetailSales");
            builder.HasKey(ds => new { ds.ProductId, ds.SaleId });

            builder.HasOne(ds => ds.Product)
                .WithMany(p => p.DetailSales);

            builder.HasOne(ds => ds.Sale)
                .WithMany(s => s.DetailSales);
              
        }
    }
}
