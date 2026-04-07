using MyStore.Entidades;
using MyStore.Models;
using MyStore.Repositorios;
using System.Linq.Expressions;

namespace MyStore.Servicios
{
    public class ProductoServicio
    {
        RepositorioGenerico<Categoria> _repositorioCategoria;
        RepositorioGenerico<Producto> _repositorioProducto;
        IWebHostEnvironment _webHostEnvironment;

        public async Task<IEnumerable<ProductoVM>> TraerTodosAsync()
        {
           var productos = await _repositorioProducto.TraerTodosAsync(
               incluidos: new Expression<Func<Producto, object>>[] {x=> x.Categoria}            
               
               );
            var productoVM = productos.Select(item =>
                new ProductoVM
                {
                    ProductoId= item.ProductoId,
                    Categoria = new CategoriaVM
                    {
                        CategoriaId = item.CategoriaId,
                        Nombre = item.Categoria.Nombre
                    },
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    Stock = item.Stock,
                    NombreImagen = item.NombreImagen,


                }).ToList();

            return productoVM;




        }
    }
}
