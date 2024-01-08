using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RecipeApi.DTO.Authentication;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            var userExists = await _userManager.FindByNameAsync(dto.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Models.Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.Username,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Models.Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            //Add claim policy
            if (dto.IsAdmin)
            {
                var userClaim = new Claim("IsAdmin", string.Empty);
                await _userManager.AddClaimAsync(user, userClaim);
            }

            return Ok(new Models.Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                //claims opvragen en toevoegen aan lijst
                var existingClaims = await _userManager.GetClaimsAsync(user);

                authClaims.AddRange(existingClaims);

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
