using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Repositories;

public interface IProductoRepository : IRepository<Producto>
{
    Task<Producto> UpdateAsync(Producto producto);
    Task<Producto> UpdateStockAsync(int id, int stock);
}
