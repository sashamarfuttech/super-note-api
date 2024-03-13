using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperNote.DataAccess.DataAccess;
using SuperNote.DataAccess.Notes;
using SuperNote.Domain.Abstractions.DataAccess;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess;

public static class DataAccessServices
{
    private const string InMemoryDatabaseName = "SuperNoteInMemoryDatabase";

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string? connectionString)
    {
        if (!string.IsNullOrEmpty(connectionString))
        {
            services.AddDbContext<SuperNoteContext>(options => options.UseNpgsql(connectionString));
        }
        else
        {
            services.AddDbContext<SuperNoteContext>(options => options.UseInMemoryDatabase(InMemoryDatabaseName));
        }

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<INotesRepository, NotesRepository>();

        return services;
    }
}