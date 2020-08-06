using Common.WebStore.Domain.Entities.Base.Interfaces;

namespace Common.WebStore.DomainNew.Dto
{
    public class BrandDto : INamedEntity
    {
        public int Id { get; set;}
        public string Name { get; set; }
    }
}
