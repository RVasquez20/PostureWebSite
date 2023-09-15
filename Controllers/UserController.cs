using Microsoft.AspNetCore.Mvc;
using PostureWebSite.Models;
using PostureWebSite.Models.Request;
using PostureWebSite.Repository;
using Utilities_Net_6_MVC;

namespace PostureWebSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepositoryAsync<Cliente> _clientRepository;
        private readonly IRepositoryAsync<Role> _rolesRepository;
        private readonly IRepositoryAsync<Usuario> _userRepository;
        public UserController(IRepositoryAsync<Cliente> clientRepository, 
            IRepositoryAsync<Role> rolesRepository,
            IRepositoryAsync<Usuario> userRepository)
        {
            _clientRepository = clientRepository;
            _rolesRepository = rolesRepository;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> ListarUsuarios()
        { 
            var oClients=await _clientRepository.GetAllWithInlcudes(c=>c.IdUsuarioNavigation,
                c => c.IdUsuarioNavigation.IdRolNavigation);
            var response= oClients.Select(c => new ListUsersVM
            {
                IdCliente=c.IdCliente,
                IdUsuario=c.IdUsuario,
                Nombres=c.Nombres,
                Apellidos=c.Apellidos,
                Email = c.Email,
                FechaRegistro=DateTime.Parse(c.FechaRegistro.ToString()).ToString("dd/MM/yyyy"),
                Username=c.IdUsuarioNavigation.Username,
                Rol=c.IdUsuarioNavigation.IdRolNavigation.Rol
            });
            return Json(new { data = response });
        }

        public async Task<IActionResult> Create()
        {
            var oRoles=(List<Role>)await _rolesRepository.GetAll();

            ViewData["Roles"] =SelectListItemHelper
                                .ToSelectListItems(oRoles
                                ,r=>r.Rol,
                                r=>r.IdRol.ToString());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRequest model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var oUser=new Usuario
            {
                Username=model.Username,
                Password=model.Password,
                IdRol=model.IdRol
            };
            var oClient=new Cliente
            {
                Nombres=model.Nombres,
                Apellidos=model.Apellidos,
                Email=model.Email,
                FechaRegistro=DateTime.Now,
                IdUsuarioNavigation=oUser
            };
            await _userRepository.Insert(oUser);
            await _clientRepository.Insert(oClient);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var oUser=await _userRepository.GetByID(id);
            var oClient=await _clientRepository.GetByID(oUser.IdUsuario);
            var oRoles=(List<Role>)await _rolesRepository.GetAll();

            ViewData["Roles"] = SelectListItemHelper
                                .ToSelectListItems(oRoles
                                , r => r.Rol,
                                r => r.IdRol.ToString(),
                                oUser.IdRol.ToString());
            var model=new UserRequest
            {
                IdUsuario=oUser.IdUsuario,
                Nombres=oClient.Nombres,
                Apellidos=oClient.Apellidos,
                Email=oClient.Email,
                Username=oUser.Username,
                Password=oUser.Password
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserRequest model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var oUser=await _userRepository.GetByID(model.IdUsuario);
            var oClient=await _clientRepository.GetByID(oUser.IdUsuario);
            oUser.Username=model.Username;
            oClient.Nombres=model.Nombres;
            oClient.Apellidos=model.Apellidos;
            oClient.Email=model.Email;
            await _userRepository.Update(oUser);
            await _clientRepository.Update(oClient);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return Json(new { success = true });
        }
    }
}
