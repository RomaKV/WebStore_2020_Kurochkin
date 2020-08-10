using Common.WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.WebStore.Interfaces
{
    public interface IUsersClient : 
         IUserStore<User>,
         IUserLoginStore<User>,
         IUserRoleStore<User>,
         IUserClaimStore<User>,
         IUserPasswordStore<User>,
         IUserTwoFactorStore<User>,
         IUserEmailStore<User>,
         IUserPhoneNumberStore<User>,        
         IUserLockoutStore<User>
         
         
    { }
}
