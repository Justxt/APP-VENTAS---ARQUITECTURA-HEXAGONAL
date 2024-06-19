using AppSale.Domain.Interfaces.Repositories;
using AppSale.Aplications.Interfaces;
using AppSale.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Aplications.Services
{
    public class ProductService : IBaseService<Product, Guid>
    {
        private readonly IBaseRepository<Product, Guid> _productRepository;

        public ProductService(IBaseRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }


        public Product Add(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("El producto es requerido");

            var product = _productRepository.Add(entity);
            _productRepository.SaveChanges();
            return product;
        }

        public void Delete(Guid entityID)
        {
            _productRepository.Delete(entityID);
            _productRepository.SaveChanges();
        }

        public void Edit(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("El producto es requerido para editar");

            _productRepository.Edit(entity);
            _productRepository.SaveChanges();
        }

        public List<Product> List()
        {
            return _productRepository.List();
        }

        public Product SelectByID(Guid entityID)
        {
            return _productRepository.SelectByID(entityID);
        }
    }
}
