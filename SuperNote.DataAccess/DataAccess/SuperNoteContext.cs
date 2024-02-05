using Microsoft.EntityFrameworkCore;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.DataAccess;

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