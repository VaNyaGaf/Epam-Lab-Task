using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Infrastructure.Authorization.Models;
using GameStore.PL.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AuthUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, UserManager<AuthUser> userManager, IMapper mapper, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            AuthUser user = _mapper.Map<AuthUser>(signUpModel);
            IdentityResult result = await _userManager.CreateAsync(user, signUpModel.Password);

            if (result.Succeeded)
            {
                string token = _tokenGenerator.GetToken(await GetUserRoles(user));
                return Ok(new { token, user });
            }

            return BadRequest();
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            AuthUser user = await _userManager.FindByEmailAsync(signInModel.Email);
            var result = await _userManager.CheckPasswordAsync(user, signInModel.Password);

            if (result)
            {
                string token = _tokenGenerator.GetToken(await GetUserRoles(user));
                return Ok(new { token, user });
            }

            return BadRequest();
        }

        private async Task<List<Claim>> GetUserRoles(AuthUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            List<Claim> userClaims = new List<Claim>();
            foreach (var r in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, r));
            }

            return userClaims;
        }
    }
}