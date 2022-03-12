using Inventory.Core.DTOs.Productos;
using Inventory.Core.DTOs.Usuarios;

namespace Inventory.Core.DTOs.Entradas;

public class EntradaDetail
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public EntradaSalidaProductoDetail Producto { get; set; } = null!;
    public UsuarioDetail Creador { get; set; } = null!;
    public UsuarioDetail Modificador { get; set; } = null!;
}


