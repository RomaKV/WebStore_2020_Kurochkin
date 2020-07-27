using Common.WebStore.Domain.Entities.Base.Interfaces;

namespace Common.WebStore.Domain.Entities.Base
{
    public class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
