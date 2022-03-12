using Inventory.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly InventoryContext _db;
    private DbSet<TEntity> dbSet;
    public Repository(InventoryContext db)
    {
        _db = db;
        dbSet = _db.Set<TEntity>();
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await dbSet.AddRangeAsync(entities);
        return entities;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = null!)
    {
        IQueryable<TEntity> query = dbSet;

        if (predicate is not null)
            query = query.Where(predicate);

        if (includeProperties is not null)
        {
            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);
        }

        if (orderBy is not null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null!, string includeProperties = null!)
    {
        IQueryable<TEntity> query = dbSet;

        if (predicate is not null)
            query = query.Where(predicate);

        if (includeProperties is not null)
        {
            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);
        }

        return await query.FirstOrDefaultAsync();
    }

    public void Remove(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveById(int id)
    {
        var dbEntity = dbSet.Find(id);
        Remove(dbEntity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        dbSet.RemoveRange(entities);
    }
}