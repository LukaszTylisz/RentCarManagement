﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace RentCarManagement.Server.IRepository;

public interface IGenericRepository<T> where T : class
{
    Task<IList<T>> GetAll(
        Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null
    );

    Task<T> Get(Expression<Func<T, bool>> expression,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

    Task Insert(T entity);
    Task InsertRange(IEnumerable<T> entities);
    Task Delete(int id);
    void DeleteRange(IEnumerable<T> entities);
    void Update(T entity);
}