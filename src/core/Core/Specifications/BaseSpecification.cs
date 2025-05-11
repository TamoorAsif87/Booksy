using System.Linq.Expressions;
using Core.interfaces;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>> criteria) : ISpecification<T>
{

    public BaseSpecification() : this(null)
    {

    }
    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDesc { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    public int Skip { get; private set; }

    public int Take { get; private set; }

    public Expression<Func<T, object>>? AddIncludeExpression { get;private set; }

    public IQueryable<T> GetQuey(ISpecification<T> spec, IQueryable<T> query)
    {

        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        return query;
    }

    protected void AddOrderBy(Expression<Func<T, object>> expressionOrderBy)
    {
        OrderBy = expressionOrderBy;
    }
    protected void AddOrderByDesc(Expression<Func<T, object>> expressionOrderByDesc)
    {
        OrderByDesc = expressionOrderByDesc;
    }
    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;

    }

    protected void AddInclude(Expression<Func<T, object>> expression)
    {
        AddIncludeExpression = expression;
    }

}


