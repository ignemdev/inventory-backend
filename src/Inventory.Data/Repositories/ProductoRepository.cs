using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Repositories;
public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    private readonly InventoryContext _db;
    public ProductoRepository(InventoryContext db) : base(db) => _db = db;
    public async Task<Producto> UpdateAsync(Producto producto)
    {
        var dbProducto = await _db.Productos.FirstOrDefaultAsync(p => p.Id == producto.Id);

        if (dbProducto != null)
        {
            dbProducto!.Nombre = producto.Nombre ?? dbProducto.Nombre;
            dbProducto!.Descripcion = producto.Descripcion ?? dbProducto.Descripcion;
            dbProducto!.Precio = producto.Precio;
            dbProducto!.UnidadId = producto.UnidadId;
        }

        return dbProducto!;
    }

    public async Task<Producto> UpdateStockAsync(int id, int stock)
    {
        var dbProducto = await _db.Productos.FirstOrDefaultAsync(p => p.Id == id);

        if (dbProducto != null)
        {
            dbProducto!.Stock += stock;
        }

        return dbProducto!;
    }
}
