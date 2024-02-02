namespace SuperNote.Application.Notes.GetNotesList;

public record NotesListItemDto(Guid Id, string Text, DateTime LastModified);