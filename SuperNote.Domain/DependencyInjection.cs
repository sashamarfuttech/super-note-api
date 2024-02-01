using Microsoft.Extensions.DependencyInjection;

namespace SuperNote.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }
}