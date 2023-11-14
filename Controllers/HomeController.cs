using System.Diagnostics;
using System.IO.Ports;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using PostureWebSite.Models;
using PostureWebSite.Models.Response;
using PostureWebSite.Repository;
using Rvasquez.SerialPortLibrary;

namespace PostureWebSite.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly PostureBaseContext _context;
        private readonly IRepositoryAsync<RegistroBotone> _botoneRepository;
        //private readonly ISerialPortManager _serialPortManager;
        //public HomeController(PostureBaseContext context,
        //    IRepositoryAsync<RegistroBotone> botoneRepository,
        //    ISerialPortManager serialPortManager)
        //{
        //    this._context = context;
        //    this._botoneRepository = botoneRepository;
        //    this._serialPortManager = serialPortManager;
        //}
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

        public IActionResult Medicion()
        {
            string data;
            try
            {
               // data= _serialPortManager.WriteAndReadSerial("ActivateSensor");
                Task.Delay(2000);
            }catch(Exception ex)
            {
                //determinar si el puerto esta abierto , si lo esta cerrarlo y reintentar
               // SerialPort port = new SerialPort("COM7");
               // if (port.IsOpen)
               //     port.Close();
               // data = _serialPortManager.WriteAndReadSerial("ActivateSensor");
               // Task.Delay(2000);
            }
           // var response = JsonSerializer.Deserialize<DataRecived>(data);
            //var track = new RegistroBotone()
            //{
            //    IdUser = 1,
            //    FechaHora = DateTime.Now,
            //    Boton1 = response.BUTTON1,
            //    Boton2 = response.BUTTON2,
            //    Boton3 = response.BUTTON3,
            //    Boton4 = response.BUTTON4,
            //    Boton5 = response.BUTTON5,
            //    Boton6 = response.BUTTON6
            //};
            //_botoneRepository.Insert(track);
            //bool success = new[] { response.BUTTON1, response.BUTTON2, response.BUTTON3,
            //           response.BUTTON4, response.BUTTON5, response.BUTTON6 }
            //   .All(boton => boton == true);

                //return Json(new { access = success, data = response });
                return Json(new { access = true });
        }
    }
}