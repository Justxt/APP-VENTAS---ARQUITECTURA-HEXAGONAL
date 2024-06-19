using AppSale.Domain;
using AppSale.Domain.Interfaces.Repositories;
using AppSale.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Infrastructure.Data.Repositories
{
    public class DetailSaleRepository : IDetailRepository<DetailSale, Guid>
    {

        private ContextSale _db;

        public DetailSaleRepository(ContextSale db)
        {
            _db = db;
        }

        public DetailSale Add(DetailSale entity)
        {
            _db.detailSales.Add(entity);
            return entity;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
