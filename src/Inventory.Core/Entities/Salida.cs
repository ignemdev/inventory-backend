using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Entities;
public class Salida : BaseEntity
{
    [Range(DatabaseConstants.CantidadFieldMinRange, DatabaseConstants.CantidadFieldMaxRange)]
    public int Cantidad { get; set; }
    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;
    public int RazonId { get; set; }
    public Razon Razon { get; set; } = null!;
}
