using Common.WebStore.Domain;
using Common.WebStore.Domain.Entities;
using Common.WebStore.DomainNew.Dto;
using System.Collections.Generic;

namespace Services.WebStore.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<BrandDto> GetBrands();
        IEnumerable<ProductDto> GetProducts(ProductFilter filter);
      
        /// <summary>
        /// Получить товар по Id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сущность Product, если нашел, иначе null</returns>
        ProductDto GetProductById(int id);

        Category GetCategoryById(int id);

        Brand GetBrandById(int id);
    }
}
