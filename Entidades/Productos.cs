using System.ComponentModel.DataAnnotations;

namespace Jeremy_Castillo_Ap1_p1_.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string ?Descripcion  { get; set; }
        public int Existencia { get; set; }
        public float Costo { get; set; }
        public float ValorInventario { get; set; }
        
    }
}