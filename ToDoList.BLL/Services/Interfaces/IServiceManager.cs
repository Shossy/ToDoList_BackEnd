namespace ToDoList.BLL.Services.Interfaces;

public interface IServiceManager
{
    IToDoTasksService ToDoTasksService { get; }
}