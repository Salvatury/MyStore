using Microsoft.AspNetCore.Mvc;
using MyStore.Contexto;

namespace MyStore.Controllers
{
    public class CategoriaController(AppDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
            var categorias= _dbContext.Categorias.ToList();
            return View(categorias);
        }
    }
}
