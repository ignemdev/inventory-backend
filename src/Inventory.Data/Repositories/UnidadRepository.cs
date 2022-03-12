using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Repositories;

public class UnidadRepository : Repository<Unidad>, IUnidadRepository
{
    private readonly InventoryContext _db;
    public UnidadRepository(InventoryContext db) : base(db) => _db = db;
    public async Task<Unidad> UpdateAsync(Unidad unidad)
    {
        var dbUnidad = await _db.Unidades.FirstOrDefaultAsync(u => u.Id == unidad.Id);

        if (dbUnidad != null)
        {
            dbUnidad!.Descripcion = unidad.Descripcion ?? dbUnidad.Descripcion;
        }

        return dbUnidad!;
    }
}
