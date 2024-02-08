using ToDoList.DAL.Entities;
using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.Tasks;
using ToDoList.DAL.Repositories.Realizations.Base;

namespace ToDoList.DAL.Repositories.Realizations.Tasks;

public class ToDoTaskRepository: RepositoryBase<ToDoTask>, IToDoTaskRepository
{
    public ToDoTaskRepository(ToDoListDbContext dbContext) : base(dbContext)
    {
    }
}