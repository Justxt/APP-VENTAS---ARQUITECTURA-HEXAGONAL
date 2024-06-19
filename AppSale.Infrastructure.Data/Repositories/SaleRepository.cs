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
    public class SaleRepository : IMotionRepository<Sale, Guid>
    {

        private ContextSale _db;

        public SaleRepository(ContextSale db)
        {
            _db = db;
        }

        public Sale Add(Sale entity)
        {
            entity.SaleId = Guid.NewGuid();
            _db.sales.Add(entity);
            return entity;
        }

        public void Cancel(Guid entityID)
        {
            var saleSelected = _db.sales.Where(c => c.SaleId == entityID).FirstOrDefault();
            if (saleSelected == null)
                throw new Exception("No se puede anular una venta inexistente");
            
            saleSelected.Canceled = true;
            _db.Entry(saleSelected).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Sale> List()
        {
            return _db.sales.ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public Sale SelectByID(Guid entityID)
        {
            var saleSelected = _db.sales.Where(c => c.SaleId == entityID).FirstOrDefault();
            return saleSelected;
        }
    }
}
