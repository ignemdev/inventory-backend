using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Repositories;

public class EntradaRepository : Repository<Entrada>, IEntradaRepository
{
    private readonly InventoryContext _db;
    public EntradaRepository(InventoryContext db) : base(db) => _db = db;
    public async Task<Entrada> UpdateAsync(Entrada entrada)
    {
        var dbEntrada = await _db.Entradas.FirstOrDefaultAsync(c => c.Id == entrada.Id);

        if (dbEntrada != null)
        {
            dbEntrada!.Cantidad = entrada.Cantidad;
        }

        return dbEntrada!;
    }
}