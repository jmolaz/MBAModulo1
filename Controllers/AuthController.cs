using Microsoft.AspNetCore.Authorization;  
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MBAMODULO1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MBAMODULO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Vendedor> _userManager;
        private readonly SignInManager<Vendedor> _signInManager;

        public AuthController(UserManager<Vendedor> userManager, SignInManager<Vendedor> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, false, false);

            if (result.Succeeded)
            {
                return Ok("Login realizado com sucesso.");
            }

            return Unauthorized("Credenciais inválidas.");
        }

        [HttpGet("usuarios")]
        [Authorize] // Apenas usuários autenticados poderão acessar
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
