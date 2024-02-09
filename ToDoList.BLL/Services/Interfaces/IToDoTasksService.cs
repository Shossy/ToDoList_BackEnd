using ToDoList.BLL.DTOs;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Services.Interfaces;

public interface IToDoTasksService
{
    Task CreateAsync(ToDoTaskCreateDto toDoTaskDto);
    Task UpdateAsync(int id, ToDoTaskUpdateDto toDoTaskUpdateDto);
    Task DeleteAsync(int id);
    Task<ToDoTask> GetTaskById(int id);
    Task<IEnumerable<ToDoTaskDto>> GetAllAsync();
    
}