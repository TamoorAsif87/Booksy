using Core.Entities;

namespace Core.interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<IReadOnlyList<T>> GetEntitiesWithSpec(ISpecification<T> spec);
    public Task<T?> GetByIdAsync(Guid id);
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public Task<bool> SaveChangesAsync();

    public Task<bool> IsExists(Guid Id);
    public Task<int> CountAsync(ISpecification<T> spec);
}
