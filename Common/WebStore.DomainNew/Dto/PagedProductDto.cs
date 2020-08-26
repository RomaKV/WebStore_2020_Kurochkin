using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Dto
{
    public class PagedProductDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int TotalCount { get; set; }

    }
}
