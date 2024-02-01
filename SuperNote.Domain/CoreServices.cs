using Microsoft.Extensions.DependencyInjection;
using SuperNote.Infrastructure.Notes;

namespace SuperNote.Infrastructure;

public static class DomainServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<INotesRepository, NotesRepository>();
        
        return services;
    }
}
