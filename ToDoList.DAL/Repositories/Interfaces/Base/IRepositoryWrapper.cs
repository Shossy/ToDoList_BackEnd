using ToDoList.DAL.Repositories.Interfaces.Tasks;

namespace ToDoList.DAL.Repositories.Interfaces.Base;

public interface IRepositoryWrapper
{
    IToDoTaskRepository ToDoTaskRepository { get; }
    
    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}