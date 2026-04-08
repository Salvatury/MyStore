using MyStore.Entidades;
using MyStore.Models;
using MyStore.Repositorios;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyStore.Servicios
{
    public class ProductoServicio(
        RepositorioGenerico<Categoria> _repositorioCategoria,
        RepositorioGenerico<Producto> _repositorioProducto,
        IWebHostEnvironment _webHostEnvironment)
    {
        public async Task<IEnumerable<ProductoVM>> TraerTodosAsync()
        {
            var productos = await _repositorioProducto.TraerTodosAsync(
                incluidos: new Expression<Func<Producto, object>>[] { x => x.Categoria! }
            );

            var productoVM = productos.Select(item => new ProductoVM
            {
                ProductoId = item.ProductoId,
                CategoriaId = item.CategoriaId,
                Categoria = new CategoriaVM
                {
                    CategoriaId = item.Categoria!.CategoriaId,
                    Nombre = item.Categoria!.Nombre
                },
                Nombre = item.Nombre,
                Descripcion = item.Descripcion,
                Precio = item.Precio,
                Stock = item.Stock,
                NombreImagen = item.NombreImagen
            }).ToList();

            return productoVM;
        }

        public async Task<ProductoVM> TraerPorIdAsync(int id)
        {
            var producto = await _repositorioProducto.TraerPorIdAsync(id);
            var categorias = await _repositorioCategoria.TraerTodosAsync();

            var productoVM = new ProductoVM();

            if (producto != null)
            {
                productoVM = new ProductoVM
                {
                    ProductoId = producto.ProductoId,
                    CategoriaId = producto.CategoriaId,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    NombreImagen = producto.NombreImagen
                };
            }

            productoVM.Categorias = categorias.Select(item => new SelectListItem
            {
                Value = item.CategoriaId.ToString(),
                Text = item.Nombre
            }).ToList();

            return productoVM;
        }

        public async Task AgregarAsync(ProductoVM viewModel)
        {
            if (viewModel.ArchivoImagen != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "imagenes");
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ArchivoImagen.FileName);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.ArchivoImagen.CopyToAsync(stream);
                }

                viewModel.NombreImagen = uniqueFileName;
            }

            var entidad = new Producto
            {
                CategoriaId = viewModel.CategoriaId,
                Nombre = viewModel.Nombre,
                Descripcion = viewModel.Descripcion,
                Precio = viewModel.Precio,
                Stock = viewModel.Stock,
                NombreImagen = viewModel.NombreImagen
            };

            await _repositorioProducto.AgregarAsync(entidad);
        }

        public async Task EditarAsync(ProductoVM viewModel)
        {
            var producto = await _repositorioProducto.TraerPorIdAsync(viewModel.ProductoId);

            if (producto == null) return;

            if (viewModel.ArchivoImagen != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "imagenes");
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ArchivoImagen.FileName);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.ArchivoImagen.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(producto.NombreImagen))
                {
                    var imagenAnterior = producto.NombreImagen;
                    string borrarRutaArchivo = Path.Combine(uploadFolder, imagenAnterior);

                    if (File.Exists(borrarRutaArchivo))
                    {
                        File.Delete(borrarRutaArchivo);
                    }
                }

                viewModel.NombreImagen = uniqueFileName;
            }
            else
            {
                viewModel.NombreImagen = producto.NombreImagen;
            }

            producto.CategoriaId = viewModel.CategoriaId;
            producto.Nombre = viewModel.Nombre;
            producto.Descripcion = viewModel.Descripcion;
            producto.Precio = viewModel.Precio;
            producto.Stock = viewModel.Stock;
            producto.NombreImagen = viewModel.NombreImagen;

            await _repositorioProducto.EditarAsync(producto);
        }

        public async Task EliminarAsync(int id)
        {
            var producto = await _repositorioProducto.TraerPorIdAsync(id);
            if (producto == null) return;

            await _repositorioProducto.EliminarAsync(producto);
        }
    }
}