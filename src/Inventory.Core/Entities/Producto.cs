using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Entities;
public class Producto : BaseEntity
{

    [MaxLength(DatabaseConstants.ProductoNombreMaxLength)]
    [Required(AllowEmptyStrings = false)]
    public string Nombre { get; set; } = null!;

    [MaxLength(DatabaseConstants.ProductoDescripcionMaxLength)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    [Range(0, DatabaseConstants.StockFieldMaxRange)]
    public int Stock { get; set; }
    [Range(DatabaseConstants.PrecioFieldMinRange, DatabaseConstants.PrecioFieldMaxRange)]
    public float Precio { get; set; }
    public int UnidadId { get; set; }
    public Unidad Unidad { get; set; } = null!;
}
