using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Repositories;

public class RazonRepository : Repository<Razon>, IRazonRepository
{
    private readonly InventoryContext _db;
    public RazonRepository(InventoryContext db) : base(db) => _db = db;
    public async Task<Razon> UpdateAsync(Razon razon)
    {
        var dbRazon = await _db.Razones.FirstOrDefaultAsync(c => c.Id == razon.Id);

        if (dbRazon != null)
            dbRazon!.Descripcion = razon.Descripcion ?? dbRazon.Descripcion;

        return dbRazon!;
    }
}
