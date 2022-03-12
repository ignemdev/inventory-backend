using Inventory.Core.DTOs.Unidades;
using Inventory.Core.DTOs.Usuarios;

namespace Inventory.Core.DTOs.Productos;

public class ProductoDetail
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public int Stock { get; set; }
    public float Precio { get; set; }
    public UnidadDetail Unidad { get; set; } = null!;
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public UsuarioDetail Creador { get; set; } = null!;
    public UsuarioDetail Modificador { get; set; } = null!;
}
