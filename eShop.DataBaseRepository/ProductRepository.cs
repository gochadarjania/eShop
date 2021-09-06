using eShop.DataBaseRepository.DB;
using eShop.DataBaseRepository.DB.Models;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<List<ProductEntity>> GetProducts()
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = await (from p in context.Products
                                   where p.DateDeleted == null
                                   join u in context.Units on p.UnitId equals u.Id
                                   join img in context.ProductImages on p.Id equals img.ProductId into prodImages
                                   from img in prodImages.DefaultIfEmpty()
                                   select new ProductEntity
                                   {
                                       Id = p.Id,
                                       Name = p.Name,
                                       Price = p.Price,
                                       UnitName = u.Name,
                                       ProductImage = img == null ? "no image" : img.ImagePath,
                                       Quantuty = p.Quantuty,
                                       Description = p.Description,
                                       DateCreated = p.DateCreated
                                   }).ToListAsync();

                //var query = context.Products.Select(p => new ProductEntity
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    Price = p.Price,
                //    UnitName = p.Unit.Name,
                //    ProductImage = p.ProductImages.FirstOrDefault(i => true).ImagePath,
                //    Quantuty = p.Quantuty,
                //    Description = p.Description,
                //    DateCreated = p.DateCreated
                //});



                return query;
            }
        }

        public void InsertProduct(ProductEntity productEntity)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                List<ProductImage> productImages = new List<ProductImage>();

                productImages.Add(new ProductImage() { ImagePath = productEntity.ProductImage, IsMain = productEntity.IsMainImage = false });



                var newProduct = context.Products.Add(new Product()
                {
                    Name = productEntity.Name,
                    Price = productEntity.Price,
                    Quantuty = productEntity.Quantuty,
                    ProductImages = productImages,
                    UnitId = 2,
                    DateCreated = DateTime.Now,
                    Description = productEntity.Description
                });

                context.SaveChanges();

                var pro = newProduct;
            }
        }

        public async Task<ProductEntity> GetProduct(int id)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = await (
                            from p in context.Products
                            join u in context.Units on p.UnitId equals u.Id
                            join img in context.ProductImages on p.Id equals img.ProductId
                            where p.Id == id && p.DateDeleted == null
                            select new ProductEntity
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price,
                                UnitName = u.Name,
                                ProductImage = img.ImagePath,
                                Quantuty = p.Quantuty,
                                Description = p.Description,
                                DateCreated = p.DateCreated
                            }).FirstOrDefaultAsync();

                return query;
            }
        }

        public void UpdateProduct(int id, ProductEntity productEntity)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = (from p in context.Products
                             join u in context.Units on p.UnitId equals u.Id
                             join img in context.ProductImages on p.Id equals img.ProductId
                             where p.Id == id
                             select new ProductEntity
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Price = p.Price,
                                 UnitName = u.Name,
                                 ProductImage = img.ImagePath,
                                 Quantuty = p.Quantuty,
                                 Description = p.Description,
                                 DateCreated = p.DateCreated
                             }).FirstOrDefault();

                query = productEntity;

                context.SaveChanges();

            }
        }

        public void DeleteProduct(int id)
        {
            using (eShopDbContext context = new eShopDbContext())
            {
                var query = (from p in context.Products
                             where p.Id == id
                             select p).FirstOrDefault();

                query.DateDeleted = DateTime.Now;

                context.SaveChanges();
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
