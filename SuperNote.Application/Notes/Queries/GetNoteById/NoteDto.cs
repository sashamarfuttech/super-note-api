namespace SuperNote.Application.Notes.Queries.GetNoteById;

public record NoteDto(
    Guid Id, 
    string Text, 
    DateTime LastModified);