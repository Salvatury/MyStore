using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Servicios;

namespace MyStore.Controllers
{
    public class CategoriaController(CategoriaServicio _categoriaServicio) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categorias= await _categoriaServicio.TraerTodosAsync();

            return View(categorias);
        }
        [HttpGet]
        public async Task<IActionResult> AgregarEditar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEditar(CategoriaVM entidadVM)
        {
            if(!ModelState.IsValid) return View(entidadVM);
            await _categoriaServicio.AgregarAsync(entidadVM);
            ViewBag.Mensaje = "Categoria agregada correctamente";
            return View();
        }
    }
}
