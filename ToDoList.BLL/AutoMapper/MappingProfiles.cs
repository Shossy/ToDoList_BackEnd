using AutoMapper;
using ToDoList.BLL.DTOs;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.AutoMapper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<ToDoTask, ToDoTaskDto>();
        CreateMap<ToDoTaskCreateDto, ToDoTask>();
        CreateMap<ToDoTaskUpdateDto, ToDoTask>();
    }
}