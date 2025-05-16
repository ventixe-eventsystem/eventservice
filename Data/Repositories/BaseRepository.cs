using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
  protected readonly DataContext _context;
  protected readonly DbSet<TEntity> _dbSet;

  protected BaseRepository(DataContext context)
  {
    _context = context;
    _dbSet = _context.Set<TEntity>();
  }

  public async Task<int> CreateAsync(TEntity entity)
  {
    await _dbSet.AddAsync(entity);
    return await _context.SaveChangesAsync();
  }

  public async Task<IEnumerable<TEntity>> GetAllAsync()
  {
    var result = await _dbSet.ToListAsync();
    return result;
  }
  public async Task<TEntity?> GetByIdAsync(object id)
  {
    var result = await _dbSet.FindAsync(id);

    return result == null ? result : null;
  }
  public async Task<int> UpdateAsync(TEntity entity)
  {
    _dbSet.Update(entity);
    return await _context.SaveChangesAsync();
  }
  public async Task<int> DeleteAsync(object id)
  {
    var entity = await _dbSet.FindAsync(id);
    if (entity == null)
    {
      return 0;
    }
    _dbSet.Remove(entity);
    return await _context.SaveChangesAsync();
  }
}
