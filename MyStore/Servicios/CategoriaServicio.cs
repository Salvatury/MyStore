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

        public async Task<CategoriaVM?> TraerPorIdAsync(int id)
        {
            var categoria = await _categoriaRepositorio.TraerPorIdAsync(id);
            var categoriaVM = new CategoriaVM();
            if (categoria != null)
            {
                categoriaVM.Nombre = categoria.Nombre;
                categoriaVM.CategoriaId = categoria.CategoriaId;

            }
            return categoriaVM;

        }
        public async Task EditarAsync(CategoriaVM viewModel)
        {
            var entidad = new Categoria
            {
                CategoriaId = viewModel.CategoriaId,
                Nombre = viewModel.Nombre
            };
            await _categoriaRepositorio.EditarAsync(entidad);
        }

        public async Task EliminarAsync(int id)
        {
            var categoria = await _categoriaRepositorio.TraerPorIdAsync(id);
            await _categoriaRepositorio.EliminarAsync(categoria!);
        }

    }
}

    

