using Microsoft.EntityFrameworkCore;
using SuperNote.Infrastructure.Notes;

namespace SuperNote.DataAccess.Database;

public class SuperNoteContext : DbContext
{
    public SuperNoteContext(
        DbContextOptions<SuperNoteContext> options)
        : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SuperNoteContext).Assembly);
    }
}