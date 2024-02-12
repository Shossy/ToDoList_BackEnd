using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.BLL.AutoMapper;
using ToDoList.DAL.Persistence;
using ToDoList.DAL.Repositories.Interfaces.Base;
using ToDoList.DAL.Repositories.Realizations.Base;

namespace ToDoList.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        
        var currentAssemblies = AppDomain.CurrentDomain.Load("ToDoList.BLL");
        services.AddMediatR(currentAssemblies);
        
        services.AddAutoMapper(typeof(MappingProfiles));
    }
    
}