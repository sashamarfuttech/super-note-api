using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperNote.DataAccess.DataAccess;
using SuperNote.DataAccess.Notes;
using SuperNote.Domain.Notes;
using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.DataAccess;

public static class DataAccessServices
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddDbContext<SuperNoteContext>(options => options.UseInMemoryDatabase("super-note-in-memory-database"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<INotesRepository, NotesRepository>();

        return services;
    }
}