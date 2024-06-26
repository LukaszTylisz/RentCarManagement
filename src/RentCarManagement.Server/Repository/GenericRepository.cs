﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RentCarManagement.Server.Data;
using RentCarManagement.Server.IRepository;

namespace RentCarManagement.Server.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbcontext;
    private readonly DbSet<T> _db;
    
    public GenericRepository(ApplicationDbContext context)
    {
        _dbcontext = context;
        _db = _dbcontext.Set<T>();
    }
    
    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    {
        IQueryable<T> query = _db;

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (includes != null)
        {
            query = includes(query);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> expression,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    {
        IQueryable <T> query = _db;

        if (includes != null)
        {
            query = includes(query);
        }

        return await query
            .AsNoTracking()
            .FirstOrDefaultAsync(expression);
    }

    public async Task Insert(T entity)
    {
        await _db.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T> entities)
    {
        await _db.AddRangeAsync(entities);
    }

    public async Task Delete(int id)
    {
        var record = await _db.FindAsync(id);
        _db.Remove(record);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _db.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _db.Attach(entity);
        _dbcontext.Entry(entity).State = EntityState.Modified;
    }
}