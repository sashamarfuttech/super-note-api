namespace SuperNote.Application.Notes.GetNotes;

public record NoteDto(
    Guid Id, 
    string Text, 
    DateTime LastModified);