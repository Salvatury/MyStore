using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Servicios;

namespace MyStore.Controllers
{
    public class ProductoController(ProductoServicio _productoServicio) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var productos = await _productoServicio.TraerTodosAsync();
            return View(productos);
        }

        [HttpGet]
        public async Task<IActionResult> AgregarEditar(int id)
        {
            var productoVM = await _productoServicio.TraerPorIdAsync(id);
            return View(productoVM);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEditar(ProductoVM entidadVM)
        {
            ViewBag.Mensaje = null;

            if (!ModelState.IsValid) return View(entidadVM);

            if (entidadVM.ProductoId == 0)
            {
                await _productoServicio.AgregarAsync(entidadVM);
                ModelState.Clear();
                entidadVM = await _productoServicio.TraerPorIdAsync(0);
                ViewBag.Mensaje = "Producto agregado correctamente";
            }
            else
            {
                await _productoServicio.EditarAsync(entidadVM);
                ViewBag.Mensaje = "Producto editado correctamente";
            }

            return View(entidadVM);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            await _productoServicio.EliminarAsync(id);
            return RedirectToAction("Index");
        }
    }
}