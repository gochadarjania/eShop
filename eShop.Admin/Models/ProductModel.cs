using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public string ProductImage { get; set; }
        public decimal Quantuty { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
