using eShop.DataBaseRepository.DB;
using eShop.DataBaseRepository.DB.Models;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductEntity> GetProducts()
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = context.Products.Select(p => new ProductEntity
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    UnitName = p.Unit.Name,
                    ProductImage = p.ProductImages.FirstOrDefault(i => true).ImagePath,
                    Quantuty = p.Quantuty,
                    Description = p.Description,
                    DateCreated = p.DateCreated
                });



                return query.ToList();
            }
        }

        public UnitEntity GetUnit(Unit unit)
        {
            UnitEntity unitEntity = new UnitEntity();

            unitEntity.Id = unit.Id;
            unitEntity.Name = unit.Name;

            return unitEntity;
        }
    }
}
