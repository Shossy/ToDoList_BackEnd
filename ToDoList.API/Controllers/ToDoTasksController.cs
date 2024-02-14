using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.DTOs;
using ToDoList.BLL.MediatR.ToDoTasks.Create;
using ToDoList.BLL.MediatR.ToDoTasks.Delete;
using ToDoList.BLL.MediatR.ToDoTasks.GetAll;
using ToDoList.BLL.MediatR.ToDoTasks.GetById;
using ToDoList.BLL.MediatR.ToDoTasks.Update;

namespace ToDoList.Controllers;

public class ToDoTaskController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ToDoTaskCreateDto toDoTaskCreateDto)
    {
        return HandleResult(await Mediator.Send(new CreateToDoTaskCommand(toDoTaskCreateDto)));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoTaskDto>>> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllToDoTasksQuery()));
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ToDoTaskDto>> GetById([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new GetByIdToDoTaskQuery(id)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteToDoTaskCommand(id)));
    }
    
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody]ToDoTaskUpdateDto toDoTaskUpdate)
    {
        return HandleResult(await Mediator.Send(new UpdateToDoTaskCommand(id,toDoTaskUpdate)));
    }
}