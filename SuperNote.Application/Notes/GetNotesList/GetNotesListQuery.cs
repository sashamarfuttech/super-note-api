using SuperNote.Application.Configuration.Queries;

namespace SuperNote.Application.Notes.GetNotesList;

public record GetNotesListQuery() : IQuery<IReadOnlyList<NotesListItemDto>>;