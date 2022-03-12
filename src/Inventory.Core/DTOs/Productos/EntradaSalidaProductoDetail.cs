using Inventory.Core.DTOs.Unidades;

namespace Inventory.Core.DTOs.Productos;

public class EntradaSalidaProductoDetail
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public UnidadDetail Unidad { get; set; } = null!;
}