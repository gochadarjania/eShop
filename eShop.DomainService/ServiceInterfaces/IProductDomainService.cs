﻿using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IProductDomainService
    {
        List<ProductEntity> GetProductEntities();
        void InsertProduct(ProductEntity productEntity);
    }
}
