using System.Linq.Expressions;

namespace Core.interfaces;

public interface ISpecification<T>
{
    public Expression<Func<T,bool>>? Criteria { get;}
    public Expression<Func<T,object>>? OrderBy { get;}
    public Expression<Func<T,object>>? OrderByDesc { get;}
    public bool IsPagingEnabled { get; }
    public int Skip { get; }
    public int Take { get; }
    public Expression<Func<T,object>>? AddIncludeExpression { get; }
    public IQueryable<T> GetQuey(ISpecification<T> spec, IQueryable<T> query);
}

