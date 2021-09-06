using eShop.Admin.Attributes;
using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Product()
        {
            var productDTOList = await _productApplicationService.GetProducts();
            
            //List<ProductModel> productModelList = new List<ProductModel>();

            var query = (from p in productDTOList
                         select new ProductModel
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

            //foreach (ProductDTO item in productDTOList)
            //{
            //    productModelList.Add(new ProductModel()
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

            //ProductListModel productListModel = new ProductListModel();
            //productListModel.Products = productModelList;
            return View(query);
        }

        [HttpPost]
        //[Route("ProductInsert")]
        [Authorize]
        public IActionResult InsertProduct(string Name, string Price, string Quantuty, string Description, List<IFormFile> ImgFile)
        {
            List<string> images = Upload(ImgFile).Result;

            ProductModel productModel = new ProductModel()
            {
                Name = Name,
                Price = Convert.ToDecimal(Price),
                Quantuty = Convert.ToDecimal(Quantuty),
                Description = Description,
                ProductImage = images.FirstOrDefault()
            };


            _productApplicationService.InsertProduct(AutoMapperExtensions.MapObject<ProductModel, ProductDTO>(productModel));

            return PartialView((productModel));
        }

        public IActionResult ProductPV(ProductModel productModel)
        {

            return PartialView(productModel);
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {

            ProductModel productModel = new ProductModel()
            {
            };
            return Json(productModel);
        }

        public IActionResult UpdateProduct(int id, string Name, string Price, string Quantuty, string Description, string Img)
        {
            return View();
        }

        public void DeleteProduct(int id)
        {
            _productApplicationService.DeleteProduct(id);

        }

        public async Task<List<string>> Upload(List<IFormFile> files)
        {
            List<string> imagesPath = new List<string>();

            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\upload\\");
                bool basePathExists = Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var exstension = Path.GetExtension(file.FileName);
                fileName = $"{Guid.NewGuid()}.{exstension}";
                var filePath = Path.Combine(basePath, fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                imagesPath.Add(fileName);
            }

            return imagesPath;
        }
    }
}
