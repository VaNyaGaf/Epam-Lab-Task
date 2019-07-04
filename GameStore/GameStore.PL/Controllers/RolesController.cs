using GameStore.Infrastructure.Authorization.Models;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<AuthUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET api/Roles
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRoles()
        {
            var allRoles = _roleManager.Roles.ToList();
            return Ok(allRoles);
        }

        // POST api/Roles
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            if (result.Succeeded)
                return Ok();

            return BadRequest();
        }

        // POST api/Roles/User
        [HttpPost("User")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRolesToUser(UserChangeRoleViewModel userChangeRole)
        {
            AuthUser user = await _userManager.FindByIdAsync(userChangeRole.UserId);

            if (user != null)
            {
                IEnumerable<string> userRoles = await _userManager.GetRolesAsync(user);
                IEnumerable<string> newRoles = userChangeRole.Roles.Except(userRoles).ToList();
                await _userManager.AddToRolesAsync(user, newRoles);
                return Ok();
            }

            return BadRequest();
        }

        // DELETE api/Roles/User
        [HttpDelete("User")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRolesFromUser(UserChangeRoleViewModel userChangeRole)
        {
            AuthUser user = await _userManager.FindByIdAsync(userChangeRole.UserId);

            if (user != null)
            {
                var result = await _userManager.RemoveFromRolesAsync(user, userChangeRole.Roles);

                if (result.Succeeded)
                    return Ok();
            }

            return BadRequest();
        }
    }
}