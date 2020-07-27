using Common.WebStore.Domain.Entities.Base.Interfaces;

namespace Common.WebStore.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Количество товаров бренда
        /// </summary>
        public int ProductsCount { get; set; }

        public int Order { get; set; }
    }

}
