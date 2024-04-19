using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using VetTextShifo.Data.DbContexts;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Auditable
{
    private readonly DbContext _dbcontext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _dbcontext = context;
        _dbSet = context.Set<TEntity>();
    }
    public async ValueTask<TEntity> CreateAsync(TEntity? entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        

        return entry.Entity;
    }

    public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entityToDelete = await _dbSet.SingleOrDefaultAsync(expression);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            return true;
        }
       
        return false;
    }

    public async ValueTask<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        return await GetAll().FirstOrDefaultAsync(expression);
    }

    public IQueryable<TEntity> GetAll()
    {
        IQueryable<TEntity> query = _dbSet;
        return query;
    }

    public async ValueTask SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbcontext.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity? entity)
    {
        var updating = await GetAsync(i => i.id == entity.id);

        _dbSet.Update(updating);

        return updating;
    }
}
