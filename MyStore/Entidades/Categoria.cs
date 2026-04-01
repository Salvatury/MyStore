using System.ComponentModel.DataAnnotations;

namespace MyStore.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }

    }
}
