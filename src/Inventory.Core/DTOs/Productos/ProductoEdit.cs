namespace Inventory.Core.DTOs.Productos;

public class ProductoEdit
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public float Precio { get; set; }
    public int UnidadId { get; set; }
}
