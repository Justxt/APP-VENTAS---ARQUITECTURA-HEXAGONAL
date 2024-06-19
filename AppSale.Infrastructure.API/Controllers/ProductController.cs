using AppSale.Aplications.Services;
using AppSale.Domain;
using AppSale.Infrastructure.Data.Contexts;
using AppSale.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppSale.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        ProductService CreateService()
        {
            ContextSale db = new ContextSale();
            ProductRepository repository = new ProductRepository(db);
            ProductService service = new ProductService(repository);
            return service;
        }


        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var service = CreateService();
            return Ok(service.List());
        }


        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectByID(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var service = CreateService();
            service.Add(product);
            return Ok("Producto Agregado Correctamente!");
        }


        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Product product)
        {
            var service = CreateService();
            product.ProductId = id;
            service.Edit(product);
            return Ok("Producto Actualizado Correctamente!");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok("Producto Eliminado Correctamente!");
        }

    }
}
