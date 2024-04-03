using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VetTextShifo.Data.DbContexts;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Data.Repositories;

public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : Auditable
{
    private readonly DbContext _dbcontext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext context)
    {
        _dbcontext = context;
        _dbSet = context.Set<TEntity>();
    }
    public async ValueTask<TEntity> CreateAsync(TEntity? entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        await SaveChanges();

        return entry.Entity;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var isDeleted = await GetAsync(u => u.id == id);

        if (isDeleted is null)
        {
            return false;
        }

        await SaveChanges();

        return true;
    }

    public async ValueTask<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        return await GetAll(expression).FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null)
    {
        IQueryable<TEntity> query = expression is null ? _dbSet : _dbSet.Where(expression);
        return query;
    }

    public async ValueTask SaveChanges()
    {
        await _dbcontext.SaveChangesAsync();
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity? entity)
    {
        var updating = await GetAsync(i => i.id == entity.id);

        _dbSet.Update(updating);
        await SaveChanges();

        return updating;
    }
}
