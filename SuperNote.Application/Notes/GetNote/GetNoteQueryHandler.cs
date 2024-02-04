using SuperNote.Application.Configuration.Queries;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.GetNote;

public class GetNoteQueryHandler : IQueryHandler<GetNoteQuery, NoteDto>
{
    private readonly INotesRepository _notesRepository;
    
    public GetNoteQueryHandler(INotesRepository notesRepository) 
        => _notesRepository = notesRepository;
    
    public async Task<NoteDto> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var note = await _notesRepository.GetByIdAsync(request.Id);
        return new NoteDto(note.Id, note.Text, note.LastModified);
    }
}