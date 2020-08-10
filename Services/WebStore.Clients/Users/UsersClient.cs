using Common.WebStore.DomainNew.Dto.User;
using Common.WebStore.DomainNew.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.WebStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.WebStore.Clients.Users
{
    public class UsersClient : BaseClient, IUsersClient
    {
        public UsersClient(IConfiguration configuration) : base(configuration)
        {
            this.ServiceAddress = "api/users";
        }

        protected override string ServiceAddress { get; }



        public Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            return PostAsync($"{this.ServiceAddress}/addClaims", claims);
        }


        public async Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/addClaims", new AddLoginDto { User = user, UserLoginInfo = login });

            return;
        }

        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/role/{roleName}", user);
            return;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/user", user);
            var result = await request.Content.ReadAsAsync<bool>();
            return result ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/user/delete", user);
            var result = await request.Content.ReadAsAsync<bool>();
            return result ? IdentityResult.Success : IdentityResult.Failed();
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return await GetAsync<User>($"{this.ServiceAddress}/user/findByEmail/{normalizedEmail}");
        }


        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await GetAsync<User>($"{this.ServiceAddress}/user/find/{userId}");
        }

        public async Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            return await GetAsync<User>($"{this.ServiceAddress}/user/findLogin/{loginProvider}/{providerKey}");
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await GetAsync<User>($"{this.ServiceAddress}/user/normal/{normalizedUserName}");
        }

        public async Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getAccessFailedCount", user);
            return await request.Content.ReadAsAsync<int>();
        }

        public async Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getClaims", user);
            return await request.Content.ReadAsAsync<IList<Claim>>();
        }

        public async Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getEmail", user);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getEmailConfirmed", user);
            return await request.Content.ReadAsAsync<bool>();
        }

        public async Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getLockoutEnabled", user);
            return await request.Content.ReadAsAsync<bool>();
        }

        public async Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getLockoutEndDate", user);
            return await request.Content.ReadAsAsync<DateTimeOffset?>();
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getLogins", user);
            return await request.Content.ReadAsAsync<IList<UserLoginInfo>>();
        }

        public async Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getNormalizedEmail", user);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getNormalizedUserName", user);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getPasswordHash", user);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getPhoneNumber", user);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getPhoneNumberConfirmed", user);
            return await request.Content.ReadAsAsync<bool>();
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/roles", user);
            return await request.Content.ReadAsAsync<IList<string>>();
        }

        public async Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getTwoFactorEnabled", user);
            return await request.Content.ReadAsAsync<bool>();
        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/userId", user);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/userName", user);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getUsersForClaim", claim);
            return await request.Content.ReadAsAsync<IList<User>>();
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            return await GetAsync<List<User>>($"{this.ServiceAddress}/usersinrole/{roleName}");
        }

        public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/hasPassword", user);
            return await request.Content.ReadAsAsync<bool>();
        }

        public async Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/incrementAccessFailedCount", user);
            return await request.Content.ReadAsAsync<int>();
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/inrole/{roleName}", user);
            return await request.Content.ReadAsAsync<bool>();
        }

        public async Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/removeClaim", new RemoveClaimsDto { User = user, Claims = claims });
            return;

        }

        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/role/delete/{roleName}", user);
            return;
        }

        public async Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/removeLogin/{loginProvider}/{providerKey}", user);
            return;
        }

        public async Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/replaceClaim", new ReplaceClaimsDto { User = user, Claim = claim, NewClaim = newClaim });
            return;
        }

        public async Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/resetAccessFailedCount", user);
            return;
        }

        public async Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/setEmail", user);
            return;
        }

        public async Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/setEmailConfirmed/{confirmed}", user);
            return;
        }

        public async Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/setLockoutEnabled/{enabled}", user);
            return;
        }

        public async Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/setLockoutEndDate", new SetLockoutDto { User = user, LockoutEnd = lockoutEnd });
            return;
        }

        public async Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/setEmail/{normalizedEmail}", user);
            return;
        }

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            await PostAsync($"{this.ServiceAddress}/setNormalizedUserName/{normalizedName}", user);
            return;
        }

        public async Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/setPasswordHash", user);
            return;
        }

        public async Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/setPhoneNumber/{phoneNumber}", user);
            return;
        }

        public async Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/setPhoneNumberConfirmed/{confirmed}", user);
            return;
        }

        public async Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/setTwoFactor/{enabled}", user);
            return;
        }

        public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/userName/{userName}", user);
            return;
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/user", user);
            var result = await request.Content.ReadAsAsync<bool>();
            return result ? IdentityResult.Success : IdentityResult.Failed();
        }
    }
}
