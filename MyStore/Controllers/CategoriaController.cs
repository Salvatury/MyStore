using Microsoft.AspNetCore.Mvc;
using MyStore.Contexto;
using MyStore.Models;

namespace MyStore.Controllers
{
    public class CategoriaController(AppDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
            var categorias= _dbContext.Categorias.Select(item =>
              new CategoriaVM
              {
                  CategoriaId = item.CategoriaId,
                  Nombre = item.Nombre
              }).ToList();

            return View(categorias);
        }
    }
}
