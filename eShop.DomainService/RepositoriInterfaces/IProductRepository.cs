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
        List<ProductEntity> GetProducts();

        void InsertProduct(ProductEntity productEntity);
    }
}
