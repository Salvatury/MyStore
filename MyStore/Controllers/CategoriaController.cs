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
        public async Task<IActionResult> AgregarEditar(int id)
        {
            var categoriaVM = await _categoriaServicio.TraerPorIdAsync(id);
            return View(categoriaVM);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEditar(CategoriaVM entidadVM)
        {
            ViewBag.Mensaje = null;
            if (!ModelState.IsValid)return View(entidadVM);
            if(entidadVM.CategoriaId == 0)
            {
                await _categoriaServicio.AgregarAsync(entidadVM);
                ModelState.Clear();
                entidadVM = new CategoriaVM();
                ViewBag.mensaje = "Categoria agregada correctamente";
            }
            else
            {
                await _categoriaServicio.EditarAsync(entidadVM);
                ViewBag.Mensaje = "Categoria editada correctamente";
            }
            return View(entidadVM);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            await _categoriaServicio.EliminarAsync(id);
            return RedirectToAction("Index");
        }
    }
}
