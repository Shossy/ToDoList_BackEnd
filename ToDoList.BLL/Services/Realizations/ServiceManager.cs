using AutoMapper;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.Services.Realizations;

public class ServiceManager : IServiceManager
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private IToDoTasksService? _toDoTasksService;

    public ServiceManager(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public IToDoTasksService ToDoTasksService
    {
        get
        {
            if (_toDoTasksService is null)
            {
                _toDoTasksService = new ToDoTasksService(_repositoryWrapper, _mapper);
            }

            return _toDoTasksService;
        }
    }
}