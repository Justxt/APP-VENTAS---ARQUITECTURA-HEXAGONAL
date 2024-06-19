using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductCost { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductStock { get; set; }

        public List<DetailSale>? DetailSales { get; set; }
    }
}
