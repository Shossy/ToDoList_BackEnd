using AutoMapper;
using FluentResults;
using MediatR;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.MediatR.ToDoTasks.Update;

public class UpdateToDoTaskHandler: IRequestHandler<UpdateToDoTaskCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    public UpdateToDoTaskHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<Unit>> Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repositoryWrapper.ToDoTaskRepository.FindById(request.Id);
        if (entity is null)
        {
            
            return Result.Fail("NotFound");
        }

        _mapper.Map(request.ToDoTask, entity);
        _repositoryWrapper.ToDoTaskRepository.Update(entity);

        await _repositoryWrapper.SaveChangesAsync();
        return Result.Ok();
    }
}