using Inventory.Core.DTOs.Productos;
using Inventory.Core.DTOs.Razones;
using Inventory.Core.DTOs.Usuarios;

namespace Inventory.Core.DTOs.Salidas;

public class SalidaDetail
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public EntradaSalidaProductoDetail Producto { get; set; } = null!;
    public RazonDetail Razon { get; set; } = null!;
    public UsuarioDetail Creador { get; set; } = null!;
    public UsuarioDetail Modificador { get; set; } = null!;
}
