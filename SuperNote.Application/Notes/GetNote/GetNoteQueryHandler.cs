using FluentResults;
using Optional;
using Optional.Unsafe;
using SuperNote.Application.Configuration.Queries;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.GetNote;

public class GetNoteQueryHandler : IQueryHandler<GetNoteQuery, Result<NoteDto>>
{
    private readonly INotesRepository _notesRepository;
    
    public GetNoteQueryHandler(INotesRepository notesRepository) 
        => _notesRepository = notesRepository;
    
    public async Task<Result<NoteDto>> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        Option<Note> noteOption = await _notesRepository.GetByIdAsync(request.Id);

        if (!noteOption.HasValue)
        {
            return NoteErrors.NoteNotFound;
        }

        var note = noteOption.ValueOrDefault();
        
        NoteDto noteDto = new (note.Id, note.Text, note.LastModified);
        
        return Result.Ok(noteDto);
    }
}