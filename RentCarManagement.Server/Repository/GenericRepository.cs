using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RentCarManagement.Server.Data;
using RentCarManagement.Server.IRepository;

namespace RentCarManagement.Server.Repository;

public class GenericRepository<T>(ApplicationDbContext dbContext, DbSet<T> db) : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _db = db;
    
    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    {
        IQueryable<T> query = db;

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
        IQueryable <T> query = db;

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
        await db.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T> entities)
    {
        await db.AddRangeAsync(entities);
    }

    public async Task Delete(int id)
    {
        var record = await db.FindAsync(id);
        db.Remove(record);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        db.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        db.Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
    }
}