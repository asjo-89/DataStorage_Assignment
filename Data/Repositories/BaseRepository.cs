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

    //public async Task<TEntity> CreateAsync(TEntity entity)
    //{
    //    if (entity == null) return null!;
    //    try
    //    {
    //        await _context.Set<TEntity>().AddAsync(entity);
    //        return entity;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Error creating customer : {ex.Message}");
    //        return null!;
    //    }
    //}

    //public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    //{
    //    try
    //    {
    //        return await _context.Set<TEntity>().ToListAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Error getting list from database : {ex.Message}");
    //        return [];
    //    }
    //}

    //public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    //{
    //    try
    //    {
    //        var entity = await _context.Set<TEntity>()
    //            .FirstOrDefaultAsync(expression);
    //        if (entity == null) return null!;

    //        return entity;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Error finding entity in database : {ex.Message}");
    //        return null!;
    //    }
    //}


    //public async Task<TEntity?> UpdateAsync(TEntity updatedEntity)
    //{
    //    try
    //    {
    //        if (updatedEntity == null) return null!;

    //        var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
    //        if (entityToUpdate != null)
    //        {
    //            _context.Entry(entityToUpdate)
    //                .CurrentValues.SetValues(updatedEntity);
    //            return updatedEntity ?? null!;
    //        }
    //        return null!;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Error updating entity {ex.Message}");
    //        return null!;
    //    }
    //}

    //public async Task<bool> DeleteAsync(TEntity entity)
    //{
    //    try
    //    {
    //        TEntity? deleteEntity = await _context.Set<TEntity>()
    //            .FirstOrDefaultAsync(e => e.Id == entity.Id);
    //        if (deleteEntity == null) return false;

    //        _context.Set<TEntity>().Remove(deleteEntity);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Failed to delete: {ex.Message}");
    //        return false;
    //    }
    //}

}
