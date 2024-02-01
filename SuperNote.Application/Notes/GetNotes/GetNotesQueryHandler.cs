using SuperNote.Application.Configuration.Queries;
using SuperNote.Infrastructure.Notes;
using System.Linq;

namespace SuperNote.Application.Notes.GetNotes;

public class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, NoteDto>
{
    private INotesRepository _notesRepository;
    
    public GetNotesQueryHandler(INotesRepository notesRepository)
    {
        _notesRepository = notesRepository;
    }
    
    public async Task<NoteDto> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var note = await _notesRepository.GetNoteAsync(request.NoteId);

        return new NoteDto (note.Id, note.Text, note.LastModified);
    }
}