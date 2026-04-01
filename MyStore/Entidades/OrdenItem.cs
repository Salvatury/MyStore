namespace MyStore.Entidades
{
    public class OrdenItem
    {
        public int OrdenItemId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnidad { get; set; }

        public Orden? Orden { get; set; }
        public Producto? Producto { get; set; }


    }
}
