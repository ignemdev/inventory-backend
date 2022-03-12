using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services;

public interface IProductoServices
{
    Task<IEnumerable<Producto>> GetAllProductos();
    Task<Producto> AddProducto(Producto producto);
    Task<Producto> UpdateProducto(Producto producto);
    Task<Producto> GetProductoById(int productoId);
    Task<Producto> DeleteProductoById(int productoId);
    Task<IEnumerable<Entrada>> GetProductoEntradasById(int productoId);
    Task<IEnumerable<Salida>> GetProductoSalidasById(int productoId);
}
