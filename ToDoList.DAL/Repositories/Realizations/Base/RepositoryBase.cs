using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.DAL.Repositories.Realizations.Base;

public class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    private readonly ToDoListDbContext _dbContext;
    
    public RepositoryBase(ToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public void Create(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
}