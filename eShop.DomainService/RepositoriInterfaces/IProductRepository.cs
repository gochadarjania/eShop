using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetProducts();

        void DeleteProduct(int id);

        void InsertProduct(ProductEntity productEntity);
    }
}
