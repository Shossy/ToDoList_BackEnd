using AutoMapper;
using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.MediatR.ToDoTasks.GetAll;

public class GetAllToDoTasksHandler: IRequestHandler<GetAllToDoTasksQuery, Result<IEnumerable<ToDoTaskDto>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    public GetAllToDoTasksHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }
    public async Task<Result<IEnumerable<ToDoTaskDto>>> Handle(GetAllToDoTasksQuery request, CancellationToken cancellationToken)
    {
        var entitiesList = await _repositoryWrapper.ToDoTaskRepository.GetAllAsync();
        return Result.Ok(_mapper.Map<IEnumerable<ToDoTaskDto>>(entitiesList.AsEnumerable()));
    }
}