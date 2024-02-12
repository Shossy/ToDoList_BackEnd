using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.MediatR.ToDoTasks.GetAll;

public record GetAllToDoTasksQuery() : IRequest<Result<IEnumerable<ToDoTaskDto>>>
{
    
}