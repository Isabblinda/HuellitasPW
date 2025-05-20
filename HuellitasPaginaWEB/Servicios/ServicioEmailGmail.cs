
    using HuellitasPaginaWEB.Models;
    using System.Net;
    using System.Net.Mail;
    using System.Net.NetworkInformation;
namespace HuellitasPaginaWEB.Servicios
{

    
        public class ServicioEmailGmail : IServicioEmail
        {
            private readonly IConfiguration configuration;

            public ServicioEmailGmail(IConfiguration configuration)
            {
                this.configuration = configuration;
            }

            public async Task Enviar(ContactoViewModel contactanos)
            {
                var emailEmisor = configuration.GetValue<string>("Configuraciones_Email:Email");
                var clave = configuration.GetValue<string>("Configuraciones_Email:Clave");
                var host = configuration.GetValue<string>("Configuraciones_Email:Host");
                var puerto = configuration.GetValue<int>("Configuraciones_Email:Puerto");

                var smtpCliente = new SmtpClient(host, puerto);
                smtpCliente.EnableSsl = true;
                smtpCliente.UseDefaultCredentials = false;

                smtpCliente.Credentials = new NetworkCredential(emailEmisor, clave);

                var mensaje = new MailMessage(emailEmisor, emailEmisor, $"El Usuario {contactanos.Nombre} quiere contactarte", contactanos.Mensaje);

                await smtpCliente.SendMailAsync(mensaje);

            }
        }
    }

