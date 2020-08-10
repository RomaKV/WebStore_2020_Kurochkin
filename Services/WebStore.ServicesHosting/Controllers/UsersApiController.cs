using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.Dto.User;
using Common.WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.DAL;
using Services.WebStore.Interfaces;

namespace Services.WebStore.ServicesHosting.Controllers
{
    [Produces ("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly UserStore<User> userStore;

        public UsersApiController(WebStoreContext context)
        {
            this.userStore = new UserStore<User>(context) { 
            AutoSaveChanges = true };
               
        }

        [HttpPost("userId")]
        public async Task<string> GetUserIdAsync([FromBody] User user)
        {
            return await this.userStore.GetUserIdAsync(user);
        }

        [HttpPost("userName")]
        public async Task<string> GetUserAsync([FromBody] User user)
        {
            return await this.userStore.GetUserIdAsync(user);
        }

        [HttpPost("role/{roleName}")]
        public async Task AddToRoleAsync([FromBody]  User user, string roleName)
        {
             await this.userStore.AddToRoleAsync(user, roleName);
             return;
        }

        [HttpPost("role/delete/{roleName}")]
        public async Task RemoveFromRoleAsync([FromBody] User user, string roleName)
        {
            await this.userStore.RemoveFromRoleAsync(user, roleName);
            return;
        }


        [HttpPost("roles")]
        public async Task<IList<string>> GetRolesAsync([FromBody] User user)
        {
            return await this.userStore.GetRolesAsync(user);
        }

        [HttpPost("inrole/{roleName}")]
        public async Task<bool> IsInRoleAsync([FromBody] User user, string roleName)
        {
            return await this.userStore.IsInRoleAsync(user, roleName);
        }

        [HttpGet("usersinrole/{roleName}")]
        public async Task<IList<User>> GetUsersInRoleAsync(string roleName)
        {
           return await this.userStore.GetUsersInRoleAsync(roleName);
        }

        [HttpPost("getClaims")]
        public async Task<IList<Claim>> GetClaimsAsync([FromBody] User user)
        {
            return await this.userStore.GetClaimsAsync(user);
        }

        [HttpPost("addClaims")]
        public async Task AddClaimsAsync(AddClaimDto claimsDto)
        {
            await this.userStore.AddClaimsAsync(claimsDto.User, claimsDto.Claim);
            return;
        }

        [HttpPost("replaceClaim")]
        public async Task ReplaceClaimAsync(ReplaceClaimsDto claimReplaceDto)
        {
            await this.userStore.ReplaceClaimAsync(claimReplaceDto.User, claimReplaceDto.Claim, claimReplaceDto.NewClaim);
            return;
        }

        [HttpPost("removeClaim")]
        public async Task RemoveClaimsAsync([FromBody] RemoveClaimsDto claimsDto)
        {
            await this.userStore.RemoveClaimsAsync(claimsDto.User, claimsDto.Claims);
            return;
        }

        [HttpPost("getUsersForClaim")]
        public async Task<IList<User>> GetUsersForClaimAsync(Claim claim)
        {
            return await this.userStore.GetUsersForClaimAsync(claim);
        }


        [HttpPost("setPasswordHash")]
        public async Task SetPasswordHashAsync([FromBody] User user, string passwordHash)
        {
            await this.userStore.SetPasswordHashAsync(user, passwordHash);
            return;
        }

        [HttpPost("getPasswordHash")]
        public async Task<string> GetPasswordHashAsync([FromBody] User user)
        {
            return await this.userStore.GetPasswordHashAsync(user);
        }

        [HttpPost("hasPassword")]
        public async Task<bool> HasPasswordAsync([FromBody] User user)
        {
            return await this.userStore.HasPasswordAsync(user);
        }

        [HttpPost("setTwoFactor/{enabled}")]
        public async Task SetTwoFactorEnabledAsync([FromBody] User user, bool enabled)
        {
            await this.userStore.SetTwoFactorEnabledAsync(user, enabled);
            return;
        }

        [HttpPost("getTwoFactorEnabled")]
        public async Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return await this.userStore.GetTwoFactorEnabledAsync(user);
        }

        [HttpPost("setEmail")]
        public async Task SetEmailAsync([FromBody] User user, string email)
        {
            await this.userStore.SetEmailAsync(user, email);
            return;
        }

        [HttpPost("getEmail")]
        public async Task<string> GetEmailAsync(User user)
        {
            return await this.userStore.GetEmailAsync(user);
        }

        [HttpPost("getEmailConfirmed")]
        public async Task<bool> GetEmailConfirmedAsync([FromBody] User user)
        {
            return await this.userStore.GetEmailConfirmedAsync(user);
        }

        [HttpPost("setEmailConfirmed/{confirmed}")]
        public async Task SetEmailConfirmedAsync([FromBody] User user, bool confirmed)
        {
            await this.userStore.SetEmailConfirmedAsync(user, confirmed);
            return;
        }

        [HttpGet("user/findByEmail/{normalizedEmail}")]
        public async Task<User> FindByEmailAsync(string normalizedEmail)
        {
            return await this.userStore.FindByEmailAsync(normalizedEmail);
        }

        [HttpPost("getNormalizedEmail")]
        public async Task<string> GetNormalizedEmailAsync([FromBody] User user)
        {
            return await this.userStore.GetNormalizedEmailAsync(user);
        }

        [HttpPost("setEmail/{normalizedEmail}")]
        public async Task SetNormalizedEmailAsync([FromBody] User user, string normalizedEmail)
        {
            await this.userStore.SetNormalizedEmailAsync(user, normalizedEmail);
            return;
        }

        [HttpPost("setPhoneNumber/{phoneNumber}")]
        public async Task SetPhoneNumberAsync([FromBody] User user, string phoneNumber)
        {
            await this.userStore.SetPhoneNumberAsync(user, phoneNumber);
            return;
        }

        [HttpPost("getPhoneNumber")]
        public async Task<string> GetPhoneNumberAsync([FromBody] User user)
        {
            return await this.userStore.GetPhoneNumberAsync(user);
        }

        [HttpPost("getPhoneNumberConfirmed")]
        public async Task<bool> GetPhoneNumberConfirmedAsync([FromBody] User user)
        {
            return await this.userStore.GetPhoneNumberConfirmedAsync(user);
        }

        [HttpPost("setPhoneNumberConfirmed/{confirmed}")]
        public async Task SetPhoneNumberConfirmedAsync([FromBody] User user, bool confirmed)
        {
            await this.userStore.SetPhoneNumberConfirmedAsync(user, confirmed);
            return;
        }

        [HttpPost("addLogin")]
        public async Task AddLoginAsync([FromBody] User user, UserLoginInfo login)
        {
            await this.userStore.AddLoginAsync(user, login);
             return;
        }

        [HttpPost("removeLogin/{loginProvider}/{providerKey}")]
        public async Task RemoveLoginAsync([FromBody] User user, string loginProvider, string providerKey)
        {
            await this.userStore.RemoveLoginAsync(user, loginProvider, providerKey);
            return;
        }

        [HttpPost("getLogins")]
        public async Task<IList<UserLoginInfo>> GetLoginsAsync([FromBody] User user)
        {
                return await this.userStore.GetLoginsAsync(user);
        }

        [HttpGet("user/findLogin/{loginProvider}/{providerKey}")]
        public async Task<User> FindByLoginAsync(string loginProvider, string providerKey)
        {
            return await this.userStore.FindByLoginAsync(loginProvider, providerKey);
        }

        [HttpPost("getLockoutEndDate")]
        public async Task<DateTimeOffset?> GetLockoutEndDateAsync([FromBody] User user)
        {
           return await this.userStore.GetLockoutEndDateAsync(user);
        }


        [HttpPost("setLockoutEndDate")]
        public async Task SetLockoutEndDateAsync([FromBody] SetLockoutDto setLockoutDto )
        {
            await this.userStore.SetLockoutEndDateAsync(setLockoutDto.User, setLockoutDto.LockoutEnd);
            return;
        }

        [HttpPost("incrementAccessFailedCount")]
        public async Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return await this.userStore.IncrementAccessFailedCountAsync(user);
        }

        [HttpPost("resetAccessFailedCount")]
        public async Task ResetAccessFailedCountAsync([FromBody] User user )
        {
            await this.userStore.ResetAccessFailedCountAsync(user);
             return;
        }


        [HttpPost("getAccessFailedCount")]
        public async Task<int> GetAccessFailedCountAsync(User user)
        {
            return await this.userStore.GetAccessFailedCountAsync(user);
        }

        [HttpPost("getLockoutEnabled")]
        public async Task<bool> GetLockoutEnabledAsync([FromBody] User user)
        {
            return await this.userStore.GetLockoutEnabledAsync(user);
        }


        [HttpPost("setLockoutEnabled/{enabled}")]
        public async Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            await this.userStore.SetLockoutEnabledAsync(user, enabled);
             return;
        }

        [HttpPost("userName")]
        public async Task<string> GetUserNameAsync(User user)
        {
            return await this.userStore.GetUserNameAsync(user);
        }

       
        [HttpPost("userName/{userName}")]
        public async Task SetUserNameAsync([FromBody] User user, string userName)
        {
            await this.userStore.SetUserNameAsync(user, userName);
             return;
        }


        [HttpPost("getNormalizedUserName")]
        public async Task<string> GetNormalizedUserNameAsync([FromBody] User user)
        {
            return await this.userStore.GetNormalizedUserNameAsync(user);
        }

        [HttpPost("setNormalizedUserName/{normalizedName}")]
        public async Task SetNormalizedUserNameAsync([FromBody] User user, string normalizedName)
        {
            await this.userStore.SetNormalizedUserNameAsync(user, normalizedName);
             return;
        }

        [HttpPost("user")]
        public async Task<IdentityResult> CreateAsync([FromBody] User user)
        {
            return await this.userStore.CreateAsync(user);
        }

        [HttpPut("user")]
        public async Task<IdentityResult> UpdateAsync(User user)
        {
            return await this.userStore.UpdateAsync(user);
        }

        [HttpPost("user/delete")]
        public async Task<IdentityResult> DeleteAsync([FromBody] User user)
        {
            return await this.userStore.DeleteAsync(user);
        }


        [HttpGet("user/find/{userId}")]
        public async Task<User> FindByIdAsync(string userId)
        {
            return await this.userStore.FindByEmailAsync(userId);
        }


        [HttpGet("user/normal/{normalizedUserName}")]
        public async Task<User> FindByNameAsync(string normalizedUserName)
        {
            return await this.userStore.FindByNameAsync(normalizedUserName);
        }

        public  void Dispose()
        {
            
        }
    }
}
