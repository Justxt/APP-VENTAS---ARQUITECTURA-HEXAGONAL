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
    public class ProductRepository : IBaseRepository<Product, Guid>
    {

        private ContextSale _db;

        public ProductRepository(ContextSale db)
        {
            _db = db;
        }

        public Product Add(Product entity)
        {
            entity.ProductId = Guid.NewGuid();
            _db.products.Add(entity);
            return entity;
        }

        public void Delete(Guid entityID)
        {
            var productSelected = _db.products.Where(c => c.ProductId == entityID).FirstOrDefault();
            if (productSelected != null)
            {
                _db.products.Remove(productSelected);
            }
        }

        public void Edit(Product entity)
        {
            var productSelected = _db.products.Where(c => c.ProductId == entity.ProductId).FirstOrDefault();
            if (productSelected != null)
            {
                productSelected.ProductName = entity.ProductName;
                productSelected.ProductDescription = entity.ProductDescription;
                productSelected.ProductCost = entity.ProductCost;
                productSelected.ProductPrice = entity.ProductPrice;
                productSelected.ProductStock = entity.ProductStock;

                _db.Entry(productSelected).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public List<Product> List()
        {
            return _db.products.ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public Product SelectByID(Guid entityID)
        {
            var productSelected = _db.products.Where(c => c.ProductId == entityID).FirstOrDefault();
            return productSelected;
        }
    }
}
