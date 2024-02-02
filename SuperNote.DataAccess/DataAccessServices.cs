using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperNote.DataAccess.Database;
using SuperNote.DataAccess.Repositories;
using SuperNote.Domain;
using SuperNote.Infrastructure.Notes;

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