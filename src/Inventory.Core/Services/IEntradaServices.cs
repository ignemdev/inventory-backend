using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services;

public interface IEntradaServices
{
    Task<IEnumerable<Entrada>> GetAllEntradas();
    Task<Entrada> AddEntrada(Entrada entrada);
    Task<Entrada> UpdateEntrada(Entrada entrada);
    Task<Entrada> GetEntradaById(int entradaId);
    Task<Entrada> DeleteEntradaById(int entradaId);
}
