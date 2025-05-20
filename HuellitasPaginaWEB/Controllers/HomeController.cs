using System.Diagnostics;
using HuellitasPaginaWEB.Models;
using HuellitasPaginaWEB.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HuellitasPaginaWEB.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly string connectionString;

        private readonly ILogger<HomeController> _logger;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.servicioEmail = servicioEmail;
        }


        public IActionResult Index()
        {
            return View();
        }

      

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("MensajeExitoso");
        }

        public IActionResult MensajeExitoso()
        {
            return View();
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
        public async Task<IActionResult> Contactanos(ContactoViewModel contactanos)
        {
            await servicioEmail.Enviar(contactanos);
            return RedirectToAction("MensajeExitoso");
        }
        
    }
}
    
