using SuperNote.Application.Configuration.Queries;
using SuperNote.Infrastructure.Notes;
using System.Linq;

namespace SuperNote.Application.Notes.GetNotesList;

public class GetNotesListQueryHandler : IQueryHandler<GetNotesListQuery, IReadOnlyList<NotesListItemDto>>
{ 
    private readonly INotesRepository _notesRepository;
    
    public GetNotesListQueryHandler(INotesRepository notesRepository) => _notesRepository = notesRepository;

    public async Task<IReadOnlyList<NotesListItemDto>> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
    {
        var notes = await _notesRepository.GetNotesAsync();
        
        return notes
            .Select(n => new NotesListItemDto(n.Id, n.Text, n.LastModified))
            .ToList();
    }
}