using HuellitasPaginaWEB.Models;

namespace HuellitasPaginaWEB.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }
}