using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services;

public interface IUnidadServices
{
    Task<IEnumerable<Unidad>> GetAllUnidades();
    Task<Unidad> AddUnidad(Unidad unidad);
    Task<Unidad> UpdateUnidad(Unidad unidad);
    Task<Unidad> GetUnidadById(int unidadId);
}
