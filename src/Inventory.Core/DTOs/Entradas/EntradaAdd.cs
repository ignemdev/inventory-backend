using Inventory.Core.DTOs.Unidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DTOs.Entradas;

public class EntradaAdd
{
    public int Cantidad { get; set; }
    public int ProductoId { get; set; }
}

