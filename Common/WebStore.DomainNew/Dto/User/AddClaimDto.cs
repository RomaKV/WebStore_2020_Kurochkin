using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Common.WebStore.DomainNew.Dto.User
{
   public class AddClaimDto
   {
        public Entities.User User { get; set; }
        public IEnumerable<Claim> Claim { get; set; }
   }
}
