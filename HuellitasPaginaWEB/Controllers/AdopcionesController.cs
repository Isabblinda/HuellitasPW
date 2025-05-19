//using HuellitasPaginaWEB.Models;
//using System.Net.Mail;
//using Microsoft.AspNetCore.Mvc;

//namespace HuellitasPaginaWEB.Controllers
//{
//    public class AdopcionesController: Controller

//    {

//            [HttpGet]
//            public IActionResult Crear()
//            {
//                return View();
//            }

//            [HttpPost]
//            public async Task<IActionResult> Crear(PerritoEncontrado perrito)
//            {
//                // Simulación de envío de correo
//                var correo = new MimeMessage();
//                correo.From.Add(MailboxAddress.Parse("admin@huellitas.com"));
//                correo.To.Add(MailboxAddress.Parse("admin@huellitas.com"));
//                correo.Subject = "Nuevo perrito encontrado para adopción";
//                correo.Body = new TextPart("plain")
//                {
//                    Text = $"Nombre: {perrito.Nombre}\nEdad: {perrito.Edad}\nDescripción: {perrito.Descripcion}\nCorreo de contacto: {perrito.ContactoCorreo}"
//                };

//                using var smtp = new SmtpClient();
//                await smtp.ConnectAsync("smtp.tuservidor.com", 587, SecureSocketOptions.StartTls);
//                await smtp.AuthenticateAsync("usuario", "contraseña");
//                await smtp.SendAsync(correo);
//                await smtp.DisconnectAsync(true);

//                TempData["Mensaje"] = "¡Gracias por ayudar! El perrito fue enviado correctamente.";
//                return RedirectToAction("Index", "Home");
//            }
//        }

//    }

using Microsoft.AspNetCore.Mvc;

namespace HuellitasPaginaWEB.Controllers
{
    public class AdopcionesController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
