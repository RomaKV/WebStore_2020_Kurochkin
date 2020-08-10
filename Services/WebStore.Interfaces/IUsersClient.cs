using Common.WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.WebStore.Interfaces
{
    public interface IUsersClient : IUserRoleStore<User>,
         IUserClaimStore<User>,
         IUserPasswordStore<User>,
         IUserTwoFactorStore<User>,
         IUserEmailStore<User>,
         IUserPhoneNumberStore<User>,
         IUserLoginStore<User>,
         IUserLockoutStore<User>
    { }
}
