using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories;
public class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _entities = context.Set<TEntity>();
    private IDbContextTransaction _transaction = null!;

    #region Transactions

    public virtual async Task BeginTransactionAsync()
    {
        _transaction ??= await _context.Database.BeginTransactionAsync();
    }

    public virtual async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public virtual async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        int result = await _context.SaveChangesAsync();
        return result;
    }

    #endregion


    #region CRUD

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        IEnumerable<TEntity> entities = await _entities.ToListAsync();
        return entities;
    }

    public virtual async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        TEntity? entity = await _entities
            .AsNoTracking()
            .FirstOrDefaultAsync(expression);
        return entity ?? null!;
    }

    public virtual TEntity UpdateAsync(TEntity entity)
    {
        return _entities.Update(entity).Entity;
    }

    public virtual void DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
    }


    public virtual async Task<bool> AlreadyExists(Expression<Func<TEntity, bool>> expression)
    {
        var result = await _entities.FirstOrDefaultAsync(expression);
        return result != null ? true : false;
    }

    #endregion
}
