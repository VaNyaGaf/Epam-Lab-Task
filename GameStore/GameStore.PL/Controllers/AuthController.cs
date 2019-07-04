using AutoMapper;
using GameStore.Infrastructure.Authorization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AuthUser> _userManager;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, UserManager<AuthUser> userManager, IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            AuthUser user = _mapper.Map<AuthUser>(signUpModel);
            IdentityResult result = await _userManager.CreateAsync(user, signUpModel.Password);

            if (result.Succeeded)
            {
                string token = await GenerateToken(user);
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
                string token = await GenerateToken(user);
                return Ok(new { token, user });
            }

            return BadRequest();
        }

        private async Task<string> GenerateToken(AuthUser user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: await GetUserRoles(user),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
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