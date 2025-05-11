﻿using Core.Entities;
using Core.interfaces;

namespace Infrastructure.Data;

public class BaseSpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);    
        }

        if(spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }

        if(spec.OrderByDesc != null)
        {
            query = query.OrderByDescending(spec.OrderByDesc);
        }

        if (spec.IsPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        return query;
    }
}
