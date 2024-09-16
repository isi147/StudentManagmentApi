using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Student_Managment.Aplication.Repositories;
using Student_Managment.Domain.Commons;
using Student_Managment.Persistence.Context;
using System.Linq.Expressions;

namespace Student_Managment.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IBaseEntity, new()
{
    protected readonly StudentManagmentDbContext _context;
    public DbSet<T> Table { get; }

    public GenericRepository(StudentManagmentDbContext context)
    {
        _context = context;
        Table = _context.Set<T>();
    }

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }
    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }
    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }
    public async Task<T?> GetByIdAsync(int id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == id);
    }

    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }
    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }
    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }
    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }
    public async Task<bool> RemoveAsync(int id)
    {
        T? model = await Table.FirstOrDefaultAsync(data => data.Id == id);
        return Remove(model!);
    }
    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }
    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

}
