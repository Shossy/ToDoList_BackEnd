using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.Base;
using ToDoList.DAL.Repositories.Interfaces.Tasks;
using ToDoList.DAL.Repositories.Realizations.Tasks;

namespace ToDoList.DAL.Repositories.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ToDoListDbContext _toDoListDbContext;

    private IToDoTaskRepository? _toDoTaskRepository;

    public RepositoryWrapper(ToDoListDbContext toDoListDbContext)
    {
        _toDoListDbContext = toDoListDbContext;
    }

    

    public IToDoTaskRepository ToDoTaskRepository
    {
        get
        {
            if (_toDoTaskRepository is null)
            {
                _toDoTaskRepository = new ToDoTaskRepository(_toDoListDbContext);
            }

            return _toDoTaskRepository;
        }
    }
    
    public int SaveChanges()
    {
        return _toDoListDbContext.SaveChanges();
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _toDoListDbContext.SaveChangesAsync();
    }
}