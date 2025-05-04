using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MBAModulo1.Core.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MBAMODULO1.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Vendedor> _signInManager;
        private readonly UserManager<Vendedor> _userManager;

        public AccountController(SignInManager<Vendedor> signInManager, UserManager<Vendedor> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Buscar o usuário pelo email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
                return View(model);
            }

            // Verifica se a senha está correta
            var result = await _signInManager.PasswordSignInAsync(user, model.Senha, model.LembrarMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Produtos");
            }

            ModelState.AddModelError(string.Empty, "Login inválido. Verifique seu e-mail e senha.");
            return View(model);
        }

        // POST: /Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete(".AspNetCore.Cookies");    
            
            // Usar SignInManager para fazer o logout
            await _signInManager.SignOutAsync();

            // Redirecionar o usuário para a página de login após o logout
            return RedirectToAction("Login", "Account");
        }

    }
}
