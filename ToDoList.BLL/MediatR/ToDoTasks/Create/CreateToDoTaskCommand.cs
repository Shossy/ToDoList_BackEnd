using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;

namespace ToDoList.BLL.MediatR.ToDoTasks.Create;

public record CreateToDoTaskCommand(ToDoTaskCreateDto ToDoTask): IRequest<Result<Unit>>
{

}