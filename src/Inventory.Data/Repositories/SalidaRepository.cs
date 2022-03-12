using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Repositories;

public class SalidaRepository : Repository<Salida>, ISalidaRepository
{
    private readonly InventoryContext _db;
    public SalidaRepository(InventoryContext db) : base(db) => _db = db;
}
