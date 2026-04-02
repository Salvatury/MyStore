using Microsoft.EntityFrameworkCore;
using MyStore.Entidades;
using MyStore.Models;
using MyStore.Repositorios;

namespace MyStore.Servicios
{
    public class CategoriaServicio(RepositorioGenerico<Categoria> _categoriaRepositorio)
    {
        public async Task<IEnumerable<CategoriaVM>> TraerTodosAsync()
        {
            var categorias = await _categoriaRepositorio.TraerTodosAsync();
            var categoriaVM = categorias.Select(item =>
              new CategoriaVM
              {
                  CategoriaId = item.CategoriaId,
                  Nombre = item.Nombre
              }
              ).ToList();

            return categoriaVM;
        }

        public async Task AgregarAsync(CategoriaVM viewModel)
        {
            var entidad = new Categoria
            {
                Nombre = viewModel.Nombre
            };
            await _categoriaRepositorio.AgregarAsync(entidad);
        }



    }
}

    

