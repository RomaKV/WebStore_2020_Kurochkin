using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.WebStore.Clients.Users
{
    public class RolesClient : BaseClient, IRoleStore<IdentityRole>
    {
        public RolesClient(IConfiguration configuration) : base(configuration)
        {
            this.ServiceAddress = "api/roles";
        }

        protected override string ServiceAddress { get; }

        public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}", role);
            var result = await request.Content.ReadAsAsync<bool>();
            return result ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/delete", role);
            var result = await request.Content.ReadAsAsync<bool>();
            return result ? IdentityResult.Success : IdentityResult.Failed();
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        public async Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await GetAsync<IdentityRole>($"{this.ServiceAddress}/user/find/{roleId}");
        }

        public async Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await GetAsync<IdentityRole>($"{this.ServiceAddress}/FindByName/{normalizedRoleName}");
        }

        public async Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getNormalizedRoleName", role);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getRoleId", role);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/getRoleName", role);
            return await request.Content.ReadAsAsync<string>();
        }

        public async Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/setNormalizedRoleName/{normalizedName}", role);
            return;
        }

        public async Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
        {
            var request = await PostAsync($"{this.ServiceAddress}/setRoleName/{roleName}", role);
            return;
        }

        public async Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var request = await PutAsync($"{this.ServiceAddress}", role);
            var result = await request.Content.ReadAsAsync<bool>();
            return result ? IdentityResult.Success : IdentityResult.Failed();

        }
    }
}
