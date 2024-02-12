using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.MediatR.ToDoTasks.GetById;

public record GetByIdToDoTaskQuery(int id) : IRequest<Result<ToDoTaskDto>>
{
    
}