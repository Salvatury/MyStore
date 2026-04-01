namespace MyStore.Entidades
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public DateTime FechaOrden { get; set; }
        public int UsuarioId { get; set; }
        public decimal PrecioTotal { get; set; }

        public Usuario? Usuario { get; set; }

        public ICollection<OrdenItem> OrdenItems { get; set; }

    }
}
