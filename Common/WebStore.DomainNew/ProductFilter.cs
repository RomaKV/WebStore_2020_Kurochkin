using System;
using System.Collections.Generic;
using System.Text;
using Common.WebStore.DomainNew.ViewModels;

namespace Common.WebStore.Domain
{
    /// <summary>
    /// Класс для фильтрации товаров
    /// </summary>
    public class ProductFilter
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public List<int> Ids { get; set; }
        public int Page { get; set; }
        public int? PageSize { get; set; }

    }

}
