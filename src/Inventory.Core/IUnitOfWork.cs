using Inventory.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core;

public interface IUnitOfWork : IDisposable
{
    IUnidadRepository Unidades { get; }
    IRazonRepository Razones { get; }
    IProductoRepository Productos { get; }
    IEntradaRepository Entradas { get; }
    ISalidaRepository Salidas { get; }
    Task SaveAsync();
}
