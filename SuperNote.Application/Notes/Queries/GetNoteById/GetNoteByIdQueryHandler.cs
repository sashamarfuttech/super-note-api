using FluentResults;
using Optional;
using Optional.Unsafe;
using SuperNote.Application.Abstractions.Queries;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Queries.GetNoteById;

public class GetNoteByIdQueryHandler : IQueryHandler<GetNoteByIdQuery, Result<NoteDto>>
{
    private readonly INotesRepository _notesRepository;
    
    public GetNoteByIdQueryHandler(INotesRepository notesRepository) 
        => _notesRepository = notesRepository;
    
    public async Task<Result<NoteDto>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        Option<Note> noteOption = await _notesRepository.GetByIdAsync(request.Id);

        if (!noteOption.HasValue)
        {
            return NoteErrors.NoteNotFound;
        }

        var note = noteOption.ValueOrDefault();
        
        NoteDto noteDto = new (note.Id.Value, note.NoteText.Value, note.LastModified);
        
        return Result.Ok(noteDto);
    }
}