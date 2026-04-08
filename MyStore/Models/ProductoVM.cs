using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class ProductoVM
    {
        public int ProductoId { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public CategoriaVM? Categoria { get; set; }

        public List<SelectListItem> Categorias { get; set; } = new();

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string? NombreImagen { get; set; }

        public IFormFile? ArchivoImagen { get; set; }
    }
}