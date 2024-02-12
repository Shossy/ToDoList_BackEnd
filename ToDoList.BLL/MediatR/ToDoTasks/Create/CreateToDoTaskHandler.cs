using AutoMapper;
using FluentResults;
using MediatR;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.MediatR.ToDoTasks.Create;

public class CreateToDoTaskHandler: IRequestHandler<CreateToDoTaskCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    public CreateToDoTaskHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<Unit>> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<DAL.Entities.ToDoTask>(request.ToDoTask);
        _repositoryWrapper.ToDoTaskRepository.Create(entity);
        await _repositoryWrapper.SaveChangesAsync();
        return Result.Ok(Unit.Value);
    }
}