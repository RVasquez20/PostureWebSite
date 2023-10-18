using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PostureWebSite.Models;
using PostureWebSite.Models.Response;
using PostureWebSite.Repository;

namespace PostureWebSite.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly PostureBaseContext _context;
        private readonly IRepositoryAsync<RegistroBotone> _botoneRepository;
        public HomeController(PostureBaseContext context,
            IRepositoryAsync<RegistroBotone> botoneRepository)
        {
            this._context = context;
            this._botoneRepository = botoneRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.RunSpAsync<DataPosture>("GetResumenBotonesPorHora");
            ViewData["DataPosture"] = data;
            return View(await _botoneRepository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}