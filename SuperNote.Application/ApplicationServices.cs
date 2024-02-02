using System.Reflection;
namespace SuperNote.Application;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AssemblyReference.CurrentAssembly));

        return services;
    }
}