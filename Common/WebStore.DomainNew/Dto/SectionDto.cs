using System;
using System.Collections.Generic;
using System.Text;
using Common.WebStore.Domain.Entities.Base.Interfaces;

namespace Common.WebStore.DomainNew.Dto
{
    public class SectionDto : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
