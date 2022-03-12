using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services;

public interface ISalidaServices
{
    Task<IEnumerable<Salida>> GetAllSalidas();
    Task<Salida> GetSalidaById(int salidaId);
    Task<Salida> AddSalida(Salida salida);
}
