using SuperNote.Application.Configuration.Queries;
using SuperNote.Infrastructure.Notes;

namespace SuperNote.Application.Notes.GetNotes;

public record GetNotesQuery : IQuery<NoteDto>
{
    public GetNotesQuery(NoteId noteId)
    {
        NoteId = noteId;
    }
    
    public NoteId NoteId { get; }
}