

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
  Task<int> CreateAsync(TEntity entity);
  Task<int> DeleteAsync(object id);
  Task<IEnumerable<TEntity>> GetAllAsync();
  Task<TEntity?> GetByIdAsync(object id);
  Task<int> UpdateAsync(TEntity entity);
}