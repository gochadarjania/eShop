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
    public class CategoryController : Controller
    {
        ICategoryApplicationService _categoryApplicationService;

        public CategoryController(ICategoryApplicationService categoryApplicationService)
        {
            _categoryApplicationService = categoryApplicationService;
        }

        [Route("Categories")]
        [Authorize]
        public IActionResult Index()
        {
            var categoryDTOList = _categoryApplicationService.GetCategories();
            List<CategoryModel> categoryModelList = new List<CategoryModel>();

            foreach (CategoryDTO item in categoryDTOList)
            {
                categoryModelList.Add(new CategoryModel()
                {
                    ID = item.ID,
                    CategoryName = item.CategoryName
                });
            }
            CategoryListModel categoryListModel = new CategoryListModel();
            categoryListModel.Categories = categoryModelList;
            return View(categoryListModel);
        }
    }
}
