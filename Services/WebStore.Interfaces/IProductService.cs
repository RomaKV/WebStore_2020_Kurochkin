using Common.WebStore.Domain;
using Common.WebStore.Domain.Entities;
using System.Collections.Generic;

namespace Services.WebStore.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
      
        /// <summary>
        /// Получить товар по Id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сущность Product, если нашел, иначе null</returns>
        Product GetProductById(int id);
    }
}
