using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Entidades;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class ProductoVM
    {
        public int ProductoId { get; set; }
        public CategoriaVM Categoria { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? NombreImagen { get; set; }
        public IFormFile? ArchivoImagen { get; set; }

    }
}
