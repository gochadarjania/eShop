using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.ServiceInterfaces;
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

        public List<ProductDTO> GetProducts()
        {
            var productEntityList = _productDomainService.GetProductEntities();

            List<ProductDTO> productDTOList = new List<ProductDTO>();

            foreach (ProductEntity item in productEntityList)
            {
                productDTOList.Add(new ProductDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    ProductImage = item.ProductImage,
                    Quantuty = item.Quantuty,
                    UnitName = item.UnitName,
                    Description = item.Description,
                    DateCreated = item.DateCreated
                });
            }

            return productDTOList;
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
