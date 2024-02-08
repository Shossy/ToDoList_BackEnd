using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace ToDoList.DAL.Repositories.Interfaces.Base;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    
    void Create(T entity);

    void Update(T entity);
    
    void Delete(T entity);
}