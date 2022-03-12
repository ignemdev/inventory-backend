using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DTOs.Salidas;

public class SalidaAdd
{
    public int Cantidad { get; set; }
    public int ProductoId { get; set; }
    public int RazonId { get; set; }
}
