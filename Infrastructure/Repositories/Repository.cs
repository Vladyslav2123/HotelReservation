using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContextFactory contextFactory;

    public Repository(ApplicationDbContextFactory factory)
    {
        this.contextFactory = factory;
    }

    public async Task<T> Add(T entity)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return createdResult.Entity;
        }
    }

    public async void AddRange(IEnumerable<T> entities)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            return context.Set<T>().Where(expression);
        }
    }

    public IEnumerable<T> GetAll()
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            return context.Set<T>().ToList();
        }
    }

    public T GetById(int id)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            return context.Set<T>().Find(id)!;
        }
    }

    public async void Remove(T entity)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async void RemoveRange(IEnumerable<T> entities)
    {
        using (ApplicationDBContext context = contextFactory.CreateDbContext())
        {
            context.Set<T>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }
    }
}