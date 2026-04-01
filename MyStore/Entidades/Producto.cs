using System.ComponentModel.DataAnnotations;

namespace MyStore.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? NombreImagen { get; set; } 
        public Categoria? Categoria { get; set; }

    }
}
