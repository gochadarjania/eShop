using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    public class ProductController : Controller
    {
        IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }
        
        [Route("Products")]
        [Authorize]
        public IActionResult Product()
        {
            var productDTOList = _productApplicationService.GetProducts();
            List<ProductModel> productModelList = new List<ProductModel>();

            foreach (ProductDTO item in productDTOList)
            {
                productModelList.Add(new ProductModel()
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
            ProductListModel productListModel = new ProductListModel();
            productListModel.Products = productModelList;
            return View(productListModel);
        }
    }
}
