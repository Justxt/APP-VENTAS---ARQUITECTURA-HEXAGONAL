using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain
{
    public class DetailSale
    {
        public Guid ProductId { get; set; }
        public Guid SaleId { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal QuantitySold { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public Product? Product { get; set; }
        public Sale? Sale { get; set; }
    }
}
