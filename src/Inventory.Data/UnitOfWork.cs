using Inventory.Core;
using Inventory.Core.Entities;
using Inventory.Core.Repositories;
using Inventory.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly InventoryContext _db;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<Usuario> _userManager;

    public UnitOfWork(
        InventoryContext db,
        IHttpContextAccessor httpContextAccessor
        ,UserManager<Usuario> userManager)
    {
        _db = db;
        Unidades = new UnidadRepository(_db);
        Razones = new RazonRepository(_db);
        Productos = new ProductoRepository(_db);
        Entradas = new EntradaRepository(_db);
        Salidas = new SalidaRepository(_db);
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public IUnidadRepository Unidades { get; private set; }

    public IRazonRepository Razones { get; private set; }

    public IProductoRepository Productos { get; private set; }

    public IEntradaRepository Entradas { get; private set; }

    public ISalidaRepository Salidas { get; private set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync()
    {
        var username = _httpContextAccessor.HttpContext.User?.Identity?.Name;
        
        if(username == null)
        {
            await _db.SaveChangesWithTimestampsAsync();
            return;
        }
        
        var usuario = await _userManager.FindByEmailAsync(username);
        await _db.SaveChangesWithUsuarioAsync(usuario.Id);
    }
}
