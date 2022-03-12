using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services;

public interface IRazonServices
{
    Task<IEnumerable<Razon>> GetAllRazones();
    Task<Razon> AddRazon(Razon razon);
    Task<Razon> UpdateRazon(Razon razon);
    Task<Razon> GetRazonById(int razonId);
}
