using Microsoft.Extensions.DependencyInjection;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Services;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Infra.Data.Repository;
namespace NDDTraining.DI.IOC
{
    public static class DI
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            
                services.AddScoped<IModuleService, ModuleService>(); 
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
