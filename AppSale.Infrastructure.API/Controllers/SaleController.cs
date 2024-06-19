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
    public class SaleController : ControllerBase
    {

        SaleService CreateService()
        {
            ContextSale db = new ContextSale();
            SaleRepository repository = new SaleRepository(db);
            ProductRepository productRepository = new ProductRepository(db);
            DetailSaleRepository detailSaleRepository = new DetailSaleRepository(db);
            SaleService service = new SaleService(repository, productRepository, detailSaleRepository);
            return service;
        }



        // GET: api/<SaleController>
        [HttpGet]
        public ActionResult<List<Sale>> Get()
        {
            var service = CreateService();
            return Ok(service.List());
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public ActionResult<Sale> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectByID(id));
        }

        // POST api/<SaleController>
        [HttpPost]
        public ActionResult Post([FromBody] Sale sale)
        {
            if (sale.DetailSales == null)
            {
                sale.DetailSales = new List<DetailSale>();
            }
            var service = CreateService();
            service.Add(sale);
            return Ok("Venta Agregada Correctamente!");
        }


        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.Cancel(id);
            return Ok("Venta Eliminada Correctamente!");
        }
    }
}
