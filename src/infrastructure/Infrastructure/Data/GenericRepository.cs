using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().AsNoTracking().FirstAsync(x => x.Id == id);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<bool> IsExists(Guid Id)
    {
        return await _context.Set<T>().AnyAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IReadOnlyList<T>> GetEntitiesWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecifications(spec).ToListAsync();
    }

    private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
    {
        return BaseSpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        var query = _context.Set<T>().AsQueryable();
        query = spec.GetQuey(spec, query);
        return await query.CountAsync();
    }
}
