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
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("tblSales");
            builder.HasKey(s => s.SaleId);

            builder.HasMany(s => s.DetailSales)
                .WithOne(ds => ds.Sale);
        }
    }
}
