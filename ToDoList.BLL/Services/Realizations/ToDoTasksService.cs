using AutoMapper;
using ToDoList.BLL.DTOs;
using ToDoList.BLL.Services.Interfaces;
using ToDoList.DAL.Entities;
using ToDoList.DAL.Repositories.Interfaces.Base;

namespace ToDoList.BLL.Services.Realizations;

public class ToDoTasksService: IToDoTasksService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;
    
    
    public ToDoTasksService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }


    public async Task CreateAsync(ToDoTaskCreateDto toDoTaskCreateDto)
    {
        var entity = _mapper.Map<ToDoTask>(toDoTaskCreateDto);
        _repositoryWrapper.ToDoTaskRepository.Create(entity);
        await _repositoryWrapper.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, ToDoTaskUpdateDto toDoTaskUpdateDto)
    {
        var entity = await _repositoryWrapper.ToDoTaskRepository.FindById(id);
        if (entity is null)
        {
            // implement custom NotFound exception
            return;
        }

        _mapper.Map(toDoTaskUpdateDto, entity);
        _repositoryWrapper.ToDoTaskRepository.Update(entity);

        await _repositoryWrapper.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _repositoryWrapper.ToDoTaskRepository.FindById(id);
        if (entity is null)
        {
            //implement custom NotFound exception
            return;
        }
        _repositoryWrapper.ToDoTaskRepository.Delete(entity);
       await _repositoryWrapper.SaveChangesAsync();
    }

    public async Task<ToDoTask> GetTaskById(int id)
    {
        var entity = await _repositoryWrapper.ToDoTaskRepository.FindById(id);
        if (entity is null)
        {
            //implement custom NotFound exception
            throw new Exception();
        }

        return entity;

    }

    public async Task<IEnumerable<ToDoTaskDto>> GetAllAsync()
    {
        var entitiesList = await _repositoryWrapper.ToDoTaskRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ToDoTaskDto>>(entitiesList);
    }
}