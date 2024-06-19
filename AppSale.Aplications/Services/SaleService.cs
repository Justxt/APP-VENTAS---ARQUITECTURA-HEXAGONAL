using AppSale.Aplications.Interfaces;
using AppSale.Domain;
using AppSale.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Aplications.Services
{
    public class SaleService : IMotionService<Sale, Guid>
    {
        IMotionRepository<Sale, Guid> _saleRepository;
        IBaseRepository<Product, Guid> _productRepository;
        IDetailRepository<DetailSale, Guid> _detailRepository;

        public SaleService(IMotionRepository<Sale, Guid> saleRepository, IBaseRepository<Product, Guid> productRepository, IDetailRepository<DetailSale, Guid> detailRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _detailRepository = detailRepository;
        }

        public Sale Add(Sale entity)
        {
            if (entity == null)
                throw new ArgumentNullException("La venta es requerida");

            var saleAdd = _saleRepository.Add(entity);
            entity.DetailSales.ForEach(detail =>
            {
                var productSelected = _productRepository.SelectByID(detail.ProductId);
                if (productSelected == null)
                    throw new ArgumentNullException("El producto no existe");

                detail.UnitCost = productSelected.ProductCost;
                detail.UnitPrice = productSelected.ProductPrice;
                detail.SubTotal = detail.UnitPrice * detail.QuantitySold;
                detail.Iva = detail.SubTotal * 15 / 100;
                detail.Total = detail.SubTotal + detail.Iva;
                _detailRepository.Add(detail);

                productSelected.ProductStock -= detail.QuantitySold;
                _productRepository.Edit(productSelected);

                entity.SaleSubTotal += detail.SubTotal;
                entity.SaleIva += detail.Iva;
                entity.SaleTotal += detail.Total;

            });

            _saleRepository.SaveChanges();
            return entity;
        }

        public void Cancel(Guid entityID)
        {
            _saleRepository.Cancel(entityID);
            _saleRepository.SaveChanges();
        }

        public List<Sale> List()
        {
            return _saleRepository.List();
        }

        public Sale SelectByID(Guid entityID)
        {
            return _saleRepository.SelectByID(entityID);
        }
    }
}
