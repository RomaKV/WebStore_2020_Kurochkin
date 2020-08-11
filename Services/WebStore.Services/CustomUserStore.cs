using Common.WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Identity;
using Services.WebStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebStore.Services
{
    public class CustomUserStore : IUsersClient
    {
        private readonly IUsersClient client;

        public CustomUserStore(IUsersClient client)
        {
            this.client = client;    
        }
        
        public Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            return this.client.AddClaimsAsync(user, claims, cancellationToken);
        }

        public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            return this.client.AddLoginAsync(user, login, cancellationToken);                       
        }

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            return this.client.AddToRoleAsync(user, roleName, cancellationToken);                          
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.CreateAsync(user, cancellationToken);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.DeleteAsync(user, cancellationToken);
        }

        public void Dispose()
        {
            this.client.Dispose();
        }

        public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return this.client.FindByEmailAsync( normalizedEmail, cancellationToken);
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return this.client.FindByIdAsync( userId,  cancellationToken);
        }

        public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            return this.client.FindByLoginAsync( loginProvider,  providerKey,  cancellationToken);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return this.client.FindByNameAsync( normalizedUserName,  cancellationToken);
        }

        public Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetAccessFailedCountAsync( user,  cancellationToken);
        }

        public Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetClaimsAsync( user,  cancellationToken);
        }

        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetEmailAsync( user,  cancellationToken);
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetEmailConfirmedAsync(user, cancellationToken);
        }

        public Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetLockoutEnabledAsync(user,  cancellationToken);
        }

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetLockoutEndDateAsync(user,  cancellationToken);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetLoginsAsync(user,  cancellationToken);
        }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetNormalizedEmailAsync(user, cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetNormalizedUserNameAsync(user,  cancellationToken);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetPasswordHashAsync(user, cancellationToken);
        }

        public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetPhoneNumberAsync(user, cancellationToken);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetPhoneNumberConfirmedAsync(user, cancellationToken);
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetRolesAsync(user, cancellationToken);
  
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetTwoFactorEnabledAsync(user, cancellationToken);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetUserIdAsync(user,  cancellationToken);
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.GetUserNameAsync(user, cancellationToken);
        }

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            return this.client.GetUsersForClaimAsync(claim,  cancellationToken);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            return this.client.GetUsersInRoleAsync( roleName, cancellationToken);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.HasPasswordAsync(user,  cancellationToken);
        }

        public Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.IncrementAccessFailedCountAsync(user,  cancellationToken);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            return this.client.IsInRoleAsync(user, roleName,  cancellationToken);
        }

        public Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            return this.client.RemoveClaimsAsync(user,  claims,  cancellationToken);
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            return this.client.RemoveFromRoleAsync( user,  roleName,  cancellationToken);
        }

        public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            return this.client.RemoveLoginAsync(user, loginProvider,  providerKey,  cancellationToken);
        }

        public Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            return this.client.ReplaceClaimAsync(user, claim, newClaim,  cancellationToken);
        }

        public Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.ResetAccessFailedCountAsync(user, cancellationToken);
        }

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            return this.client.SetEmailAsync(user, email,  cancellationToken);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            return this.client.SetEmailConfirmedAsync(user, confirmed, cancellationToken);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            return this.client.SetLockoutEnabledAsync(user, enabled, cancellationToken);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            return this.client.SetLockoutEndDateAsync(user, lockoutEnd,  cancellationToken);
        }

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            return this.client.SetNormalizedEmailAsync( user,  normalizedEmail,  cancellationToken);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            return this.client.SetNormalizedUserNameAsync(user,  normalizedName,  cancellationToken);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            return this.client.SetPasswordHashAsync(user, passwordHash,  cancellationToken);
        }

        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            return this.client.SetPhoneNumberAsync(user, phoneNumber, cancellationToken);
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            return this.client.SetPhoneNumberConfirmedAsync(user, confirmed, cancellationToken);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            return this.client.SetTwoFactorEnabledAsync(user, enabled, cancellationToken);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            return this.client.SetUserNameAsync(user, userName,  cancellationToken);
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            return this.client.UpdateAsync(user,  cancellationToken);
        }
    }
}
