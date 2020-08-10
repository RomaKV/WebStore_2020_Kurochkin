using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Services.WebStore.DAL;

namespace Services.WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/roles")]
    [ApiController]
    public class RolesApiController : ControllerBase
    {
        private readonly RoleStore<IdentityRole> roleStore;

        public RolesApiController(WebStoreContext context)
        {
            this.roleStore = new RoleStore<IdentityRole>(context);
        }

        [HttpPost]
        public async Task<bool> CreateAsync(IdentityRole role)
        {
            var result = await this.roleStore.CreateAsync(role);
         
            return result.Succeeded;         
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(IdentityRole role)
        {
            var result = await this.roleStore.UpdateAsync(role);

            return result.Succeeded;
        }

        [HttpPost("delete")]
        public async Task<bool> DeleteAsync(IdentityRole role)
        {
            var result = await this.roleStore.DeleteAsync(role);

            return result.Succeeded;
        }

        [HttpPost("getRoleId")]
        public async Task<string> GetRoleIdAsync(IdentityRole role)
        {
            return await this.roleStore.GetRoleIdAsync(role);
          
        }

        [HttpPost("getRoleName")]
        public async Task<string> GetRoleNameAsync(IdentityRole role)
        {
            return await this.roleStore.GetRoleNameAsync(role);
        }


        [HttpPost("setRoleName/{roleName}")]
        public async Task SetRoleNameAsync(IdentityRole role, string roleName)
        {
            await this.roleStore.SetRoleNameAsync(role, roleName);
            return;
        }

        [HttpPost("getNormalizedRoleName")]
        public async Task<string> GetNormalizedRoleNameAsync(IdentityRole role)
        {
            return await this.roleStore.GetRoleNameAsync(role);           
        }


        [HttpPost("setNormalizedRoleName/{normalizedName}")]
        public async Task  SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName)
        {
            await this.roleStore.SetRoleNameAsync(role, normalizedName);
            return;
        }

        [HttpGet("FindById/{roleId}")]
        public async Task<IdentityRole> FindByIdAsync(string roleId)
        {
           return  await this.roleStore.FindByIdAsync(roleId);
           
        }

        [HttpGet("FindByName/{normalizedRoleName}")]
        public async Task<IdentityRole> FindByNameAsync(string normalizedRoleName)
        {
            return await this.roleStore.FindByNameAsync(normalizedRoleName);
        }







    }
}
