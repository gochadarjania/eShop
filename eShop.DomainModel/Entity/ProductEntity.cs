using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace eShop.DomainModel.Entity
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public string ProductImage { get; set; }
        public decimal Quantuty { get; set; }
        public decimal Price { get; set; }
        public bool IsMainImage { get; set; }
        //public int UnitId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }

        //public virtual UnitEntity Unit { get; set; }
        //public virtual ICollection<ProductImageEntity> ProductImages { get; set; }
    }
}
