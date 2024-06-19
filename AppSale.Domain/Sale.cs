using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public long SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Concept { get; set; }
        public decimal SaleSubTotal { get; set; }
        public decimal SaleIva { get; set; }
        public decimal SaleTotal { get; set; }

        public Boolean Canceled { get; set; }

        public List<DetailSale> DetailSales { get; set; }
    }
}
