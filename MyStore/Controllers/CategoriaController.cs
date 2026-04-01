using Microsoft.AspNetCore.Mvc;
using MyStore.Servicios;

namespace MyStore.Controllers
{
    public class CategoriaController(CategoriaServicio _categoriaServicio) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categorias= await _categoriaServicio.GetAllAsync();

            return View(categorias);
        }
    }
}
