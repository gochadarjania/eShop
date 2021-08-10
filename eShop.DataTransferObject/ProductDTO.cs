using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public string ProductImage { get; set; }
        public decimal Quantuty { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        //public DateTime? DateChanged { get; set; }
        //public DateTime? DateDeleted { get; set; }
    }
}
