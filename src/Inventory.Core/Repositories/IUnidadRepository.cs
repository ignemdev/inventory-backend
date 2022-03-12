﻿using Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Repositories;

public interface IUnidadRepository : IRepository<Unidad>
{
    Task<Unidad> UpdateAsync(Unidad unidad);
}
