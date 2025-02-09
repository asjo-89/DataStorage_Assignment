using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;
public class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class, IEntity

    //public class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _entities = context.Set<TEntity>();

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null) return null!;
        try
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"Error creating customer : {ex.Message}");
            return null!;
        }
    }  

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"Error getting list from database : {ex.Message}");
            return [];
        }
    }

    public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>()
                .FirstOrDefaultAsync(expression);
            if (entity == null) return null!;

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error finding entity in database : {ex.Message}");
            return null!;
        }
    }

    //public async Task<TEntity> GetByPropertyAsync(Expression<Func<TEntity, bool>> expression)
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
    //        Debug.WriteLine($"Error finding entity in database {ex.Message}");
    //        return null!;
    //    }
    //}

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _context.Set<TEntity>()
                .AnyAsync(expression);
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"Error checking if entity exists : {ex.Message}");
            return false;
        }
    }

    public async Task<TEntity?> UpdateAsync(int id, TEntity updatedEntity)
    {
        try
        {
            if (updatedEntity == null) return null!;

            var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate)
                    .CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return updatedEntity ?? null!;
            }
            return null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating entity { ex.Message }");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var entity = await _context.Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return false;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting entity { ex.Message }");
            return false;
        }
    }
}
