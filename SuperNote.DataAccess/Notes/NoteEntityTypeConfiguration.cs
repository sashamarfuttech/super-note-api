using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Notes;

internal class NoteEntityTypeConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(b => b.Id);
        
        builder.Property(e => e.Id).HasConversion(id => id.Id, value => new NoteId(value));

        builder.Property(x => x.Text);
        
        builder.Property(x => x.LastModified);
    }
}