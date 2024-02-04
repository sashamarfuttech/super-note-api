namespace SuperNote.Application.Notes.GetNote;

public record NoteDto(Guid Id, string Text, DateTime LastModified);