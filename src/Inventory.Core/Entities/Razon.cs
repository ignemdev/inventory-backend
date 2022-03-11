using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Entities;
public class Razon : BaseEntity
{
    [MaxLength(DatabaseConstants.RazonDescripcionMaxLength)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;
}
