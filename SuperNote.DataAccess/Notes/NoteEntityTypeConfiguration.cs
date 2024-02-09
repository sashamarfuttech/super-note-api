using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Notes;

internal class NoteEntityTypeConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder
            .HasKey(b => b.Id);
        
        builder
            .Property(e => e.Id)
            .HasConversion(id => id.Value, value => new NoteId(value));

        builder
            .Property(e => e.NoteText)
            .HasConversion(e => e.Value, val => NoteText.Create(val).Value);
        
        builder.Property(x => x.LastModified);
    }
}