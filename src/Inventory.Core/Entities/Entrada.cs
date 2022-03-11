using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Entities;
public class Entrada : BaseEntity
{
    [Range(DatabaseConstants.CantidadFieldMinRange, DatabaseConstants.CantidadFieldMaxRange)]
    public int Cantidad { get; set; }
    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;
}
