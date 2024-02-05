namespace SuperNote.Application.Notes.Queries.GetNotesList;

public record NotesListItemDto(
    Guid Id, 
    string Text, 
    DateTime LastModified);