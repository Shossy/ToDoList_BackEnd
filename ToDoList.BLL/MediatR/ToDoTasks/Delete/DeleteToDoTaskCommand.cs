using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.MediatR.ToDoTasks.Delete;

public record DeleteToDoTaskCommand(int Id) : IRequest<Result<Unit>>
{
    
}