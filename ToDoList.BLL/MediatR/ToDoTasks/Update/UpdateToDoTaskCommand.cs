using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;

namespace ToDoList.BLL.MediatR.ToDoTasks.Update;

public record UpdateToDoTaskCommand(int Id, ToDoTaskUpdateDto ToDoTask): IRequest<Result<Unit>>
{

}