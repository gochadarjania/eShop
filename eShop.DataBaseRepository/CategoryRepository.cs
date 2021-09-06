using eShop.DataBaseRepository.DB;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<CategoryEntity> GetCategories()
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                //var query1 = context.Categories.Select(p => new CategoryEntity
                //{
                //    Id = p.Id,
                //    Name = p.Name
                //});

                var query = from c in context.Categories
                            select new CategoryEntity
                            {
                                Id = c.Id,
                                Name = c.Name
                            };



                return query.ToList();
            }
        }
    }
}
