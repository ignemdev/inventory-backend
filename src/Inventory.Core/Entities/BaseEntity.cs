using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Entities;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public int? CreadorId { get; set; }
    public Usuario? Creador { get; set; }
    public int? ModificadorId { get; set; }
    public Usuario? Modificador { get; set; }
    public DateTime? Creado { get; set; }
    public DateTime? Modificado { get; set; }
}
