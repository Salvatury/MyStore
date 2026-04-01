using Microsoft.EntityFrameworkCore;
using MyStore.Entidades;
using MyStore.Models;
using MyStore.Repositorios; 

namespace MyStore.Servicios
{
    public class CategoriaServicio(RepositorioGenerico<Categoria> _categoriaRepositorio)
    {
        public async Task<IEnumerable<CategoriaVM>> GetAllAsync()
        {
            var categorias = await _categoriaRepositorio.GetAllAsync();
            var categoriaVM = categorias.Select(item =>
              new CategoriaVM
              {
                  CategoriaId = item.CategoriaId,
                  Nombre = item.Nombre
              }).ToList();

            return categoriaVM;

        }
    }
}
