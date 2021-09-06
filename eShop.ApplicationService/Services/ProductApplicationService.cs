using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using Microsoft.EntityFrameworkCore;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private IProductDomainService _productDomainService;

        public ProductApplicationService(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }

        public void DeleteProduct(int id)
        {
            _productDomainService.DeleteProduct(id);
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var productEntityList = await _productDomainService.GetProductEntities();

            //List<ProductDTO> productDTOList = new List<ProductDTO>();

            //productDTOList = AutoMapperExtensions.MapObject<List<ProductEntity>, List<ProductDTO>>(productEntityList);

            //productEntityList.Select(x => productDTOList.Add)

            var query = (from p in productEntityList
                               select new ProductDTO
                               {
                                   Id = p.Id,
                                   Name = p.Name,
                                   Price = p.Price,
                                   UnitName = p.Name,
                                   ProductImage = p.ProductImage,
                                   Quantuty = p.Quantuty,
                                   Description = p.Description,
                                   DateCreated = p.DateCreated
                               }).ToList();

            //foreach (ProductEntity item in productEntityList)
            //{
            //    productDTOList.Add(new ProductDTO()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Price = item.Price,
            //        ProductImage = item.ProductImage,
            //        Quantuty = item.Quantuty,
            //        UnitName = item.UnitName,
            //        Description = item.Description,
            //        DateCreated = item.DateCreated
            //    });
            //}

            return query;
        }

        public void InsertProduct(ProductDTO productEntity)
        {
            _productDomainService.InsertProduct(new ProductEntity()
            {
                Name = productEntity.Name,
                Price = productEntity.Price,
                Quantuty = productEntity.Quantuty,
                Description = productEntity.Description,
                ProductImage = productEntity.ProductImage
            });
        }
    }
}
