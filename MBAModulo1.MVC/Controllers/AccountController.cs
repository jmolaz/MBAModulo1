using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MBAMODULO1.Models;
using System.Threading.Tasks;
using System;

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
            Console.WriteLine("Email recebido: " + model.Email);
            Console.WriteLine("Senha recebida: " + model.Senha);    
            Console.WriteLine("Tentando logar...");
            Console.WriteLine($"Email: {model.Email}");
            Console.WriteLine($"Senha: {(string.IsNullOrEmpty(model.Senha) ? "vazia" : "****")}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState inválido:");
                foreach (var e in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($" - {e.ErrorMessage}");
                }
                return View(model);
            }

            // Buscar o usuário pelo email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado");
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
                return View(model);
            }

            // Verifica se a senha está correta
            var result = await _signInManager.PasswordSignInAsync(user, model.Senha, model.LembrarMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Console.WriteLine("Login bem-sucedido");
                return RedirectToAction("Index", "Home");
            }

            Console.WriteLine("Login falhou:");
            Console.WriteLine($" - LockedOut: {result.IsLockedOut}");
            Console.WriteLine($" - NotAllowed: {result.IsNotAllowed}");
            Console.WriteLine($" - Requires2FA: {result.RequiresTwoFactor}");

            ModelState.AddModelError(string.Empty, "Login inválido. Verifique seu e-mail e senha.");
            return View(model);
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            Console.WriteLine("Realizando logout...");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
