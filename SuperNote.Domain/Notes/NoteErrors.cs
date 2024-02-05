namespace SuperNote.Domain.Notes;

public static class NoteErrors
{
    public static readonly NoteNotFoundError NoteNotFound = new ("Note.Not.Found", "Note not found.");
    public static readonly NoteNotFoundError TheNoteIsEmpty = new ("The.Note.Is.Empty", "The note is empty.");
}