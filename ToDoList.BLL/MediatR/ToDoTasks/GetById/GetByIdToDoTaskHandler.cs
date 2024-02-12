using AutoMapper;
using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;
using ToDoList.BLL.MediatR.ToDoTasks.Delete;
using ToDoList.BLL.MediatR.ToDoTasks.GetById;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.MediatR.ToDoTasks.GetById;

public class DeleteToDoTasksHandler: IRequestHandler<GetByIdToDoTaskQuery, Result<ToDoTaskDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    public DeleteToDoTasksHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }
    public async Task<Result<ToDoTaskDto>> Handle(GetByIdToDoTaskQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repositoryWrapper.ToDoTaskRepository.FindById(request.id);
        if (entity is null)
        {
            //implement custom NotFound exception
            return Result.Fail("NotFound");
        }

        return Result.Ok(_mapper.Map<ToDoTaskDto>(entity));
    }
}