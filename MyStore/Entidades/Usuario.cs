using System.ComponentModel.DataAnnotations;

namespace MyStore.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }
        [Required]
        public string TipoUsuario { get; set; } // "Admin" o "Cliente"

        public ICollection<Orden> Ordenes { get; set; }
    }
}
