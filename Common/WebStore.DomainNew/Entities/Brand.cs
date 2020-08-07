using Common.WebStore.Domain.Entities.Base;
using Common.WebStore.Domain.Entities.Base.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.WebStore.Domain.Entities
{
    [Table("ProductBrands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}