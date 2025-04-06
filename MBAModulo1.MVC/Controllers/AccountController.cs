using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MBAMODULO1.Models;
using System.Threading.Tasks;


namespace MBAMODULO1.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Vendedor> _signInManager;

        public AccountController(SignInManager<Vendedor> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Redireciona para a Home em caso de sucesso
            }

            ModelState.AddModelError(string.Empty, "Login inválido");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
