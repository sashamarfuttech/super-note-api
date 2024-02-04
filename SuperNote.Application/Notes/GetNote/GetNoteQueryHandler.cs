using Optional;
using Optional.Unsafe;
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
        Option<Note> noteOption = await _notesRepository.GetByIdAsync(request.Id);

        if (!noteOption.HasValue)
        {
            throw new Exception("not found");
        }

        var note = noteOption.ValueOrDefault();
        
        return new NoteDto(note.Id, note.Text, note.LastModified);
    }
}