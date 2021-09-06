using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class ProductDomainService : IProductDomainService
    {
        IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public async Task<List<ProductEntity>> GetProductEntities()
        {
            return await _productRepository.GetProducts();
        }

        public void InsertProduct(ProductEntity productEntity)
        {
            _productRepository.InsertProduct(productEntity);
        }
    }
}
