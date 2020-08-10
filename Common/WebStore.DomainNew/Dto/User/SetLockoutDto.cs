using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Dto.User
{
    public class SetLockoutDto
    {
        Entities.User User { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
