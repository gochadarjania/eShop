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
    public class CategoryApplicationService : ICategoryApplicationService
    {
        ICategoryDomainService _categoryDomainService;

        public CategoryApplicationService(ICategoryDomainService categoryDomainService)
        {
            _categoryDomainService = categoryDomainService;
        }

        public List<CategoryDTO> GetCategories()
        {
            var productEntityList = _categoryDomainService.GetCategories();

            List<CategoryDTO> categoryDTOList = new List<CategoryDTO>();

            foreach (CategoryEntity item in productEntityList)
            {
                categoryDTOList.Add(new CategoryDTO()
                {
                    ID = item.Id,
                    CategoryName = item.Name
                });
            }

            return categoryDTOList;
        }
    }
}
