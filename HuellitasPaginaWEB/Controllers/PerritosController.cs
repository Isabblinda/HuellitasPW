using HuellitasPaginaWEB.Models;
using HuellitasPaginaWEB.Data;
using Microsoft.AspNetCore.Mvc;

namespace HuellitasPaginaWEB.Controllers
{
    public class PerritosController : Controller
    {
        private readonly PerritoRepository _repo;

        public PerritosController(PerritoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var perritos = _repo.ObtenerTodos();
            return View(perritos);
        }

        public IActionResult Detalles(int id)
        {
            // Implementación para ver detalles de un perrito específico
            var perrito = _repo.ObtenerTodos().FirstOrDefault(p => p.Id == id);
            if (perrito == null)
            {
                return NotFound();
            }
            return View(perrito);
        }
    }
}