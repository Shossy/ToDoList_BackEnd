using AutoMapper;
using FluentResults;
using MediatR;
using ToDoList.BLL.DTOs;
using ToDoList.BLL.MediatR.ToDoTasks.Delete;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.MediatR.ToDoTasks.GetAll;

public class DeleteToDoTaskHandler: IRequestHandler<DeleteToDoTaskCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    public DeleteToDoTaskHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }
    public async Task<Result<Unit>> Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repositoryWrapper.ToDoTaskRepository.FindById(request.Id);
        if (entity is null)
        {
            //implement custom NotFound exception
            return Result.Fail("NotFound");
        }
        _repositoryWrapper.ToDoTaskRepository.Delete(entity);
        await _repositoryWrapper.SaveChangesAsync();
        return Result.Ok(Unit.Value);
    }
}