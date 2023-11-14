using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using PostureWebSite.Models;
using PostureWebSite.Repository;

namespace PostureWebSite.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRepositoryAsync<Usuario> _repository;
        public AuthController(IRepositoryAsync<Usuario> repository)
        {
            _repository = repository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if(!ModelState.IsValid)
                return View(model);
            var usuario=await _repository.Find(x=>x.Username==model.Username && x.Password==model.Password);
            if(usuario==null)
            {
                ModelState.AddModelError("","Usuario o contraseña incorrectos");
                return View(model);
            }
            HttpContext.Session.SetString("Usuario",JsonSerializer.Serialize(usuario));
            return RedirectToAction("Index","Home");
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
