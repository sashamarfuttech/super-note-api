using SuperNote.Application.Abstractions.Queries;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Queries.GetNotesList;

public class GetNotesListQueryHandler : IQueryHandler<GetNotesListQuery, IReadOnlyList<NotesListItemDto>>
{ 
    private readonly INotesRepository _notesRepository;
    
    public GetNotesListQueryHandler(INotesRepository notesRepository) => _notesRepository = notesRepository;

    public async Task<IReadOnlyList<NotesListItemDto>> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
    {
        var notes = await _notesRepository.GetALl();
        
        return notes
            .Select(n => new NotesListItemDto(n.Id.Value, n.NoteText.Value, n.LastModified))
            .ToList();
    }
}