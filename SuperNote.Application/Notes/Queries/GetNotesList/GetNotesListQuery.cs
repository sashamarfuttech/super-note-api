using SuperNote.Application.Abstractions.Queries;

namespace SuperNote.Application.Notes.Queries.GetNotesList;

public record GetNotesListQuery() : IQuery<IReadOnlyList<NotesListItemDto>>;