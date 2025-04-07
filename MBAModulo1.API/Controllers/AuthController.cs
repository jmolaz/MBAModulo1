using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MBAMODULO1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MBAMODULO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Vendedor> _userManager;
        private readonly SignInManager<Vendedor> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<Vendedor> userManager,
            SignInManager<Vendedor> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new Vendedor
            {
                UserName = model.Email,
                Email = model.Email,
                NomeCompleto = model.NomeCompleto
            };

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                return Ok("Usuário registrado com sucesso.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized("Usuário ou senha inválidos");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Senha, false);
            if (!result.Succeeded)
                return Unauthorized("Usuário ou senha inválidos");

            var token = GerarToken(user);
            return Ok(new { Token = token });
        }

        [HttpGet("usuarios")]
        [Authorize]
        public IActionResult GetUsuarios()
        {
            var usuarios = _userManager.Users.Select(u => new
            {
                u.Id,
                u.Email,
                u.UserName,
                ((Vendedor)u).NomeCompleto
            }).ToList();

            return Ok(usuarios);
        }

        private string GerarToken(Vendedor vendedor)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, vendedor.Id),
                new Claim(JwtRegisteredClaimNames.Email, vendedor.Email),
                new Claim("nomeCompleto", vendedor.NomeCompleto ?? "")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(double.Parse(_configuration["Jwt:ExpireHours"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // Modelos auxiliares
    public class RegisterModel
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class LoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
