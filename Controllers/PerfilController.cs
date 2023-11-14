using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostureWebSite.Models;
using PostureWebSite.Models.Request;
using PostureWebSite.Repository;

namespace PostureWebSite.Controllers
{

    public class PerfilController : Controller
    {
        private readonly IRepositoryAsync<Cliente> _clientRepository;
        private readonly IRepositoryAsync<Usuario> _userRepository;
        public PerfilController(IRepositoryAsync<Cliente> clientRepository,
            IRepositoryAsync<Usuario> userRepository)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> UserProfile()
        {
            var oUser=JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario"));
            var oClient=await  _clientRepository.Find(x=>x.IdUsuario==oUser.IdUsuario);
            var data = new UserRequest()
            {
                IdUsuario = oUser.IdUsuario,
                Username = oUser.Username,
                Nombres =oClient.Nombres,
                Apellidos = oClient.Apellidos,
                Email = oClient.Email,
                Peso = oClient.Peso,
                Altura = oClient.Altura
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfileData(UserRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var oUser=await _userRepository.GetByID(model.IdUsuario);
            var oClient=await  _clientRepository.Find(x=>x.IdUsuario==oUser.IdUsuario);
            oUser.Username=model.Username;
            oClient.Nombres=model.Nombres;
            oClient.Apellidos=model.Apellidos;
            oClient.Email=model.Email;
            oClient.Peso=model.Peso;
            oClient.Altura=model.Altura;
            if (!string.IsNullOrEmpty(model.Password))
            {
                oUser.Password=model.Password;
            }
            await _userRepository.Update(oUser);
            await _clientRepository.Update(oClient);
            TempData["Message"]="Datos actualizados correctamente";
            return RedirectToAction("UserProfile");
        }
    }
}
