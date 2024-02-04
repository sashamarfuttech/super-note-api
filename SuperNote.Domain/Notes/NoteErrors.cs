namespace SuperNote.Domain.Notes;

public static class NoteErrors
{
    public static readonly NoteNotFoundError NoteNotFound = new ("Note.Not.Found", "Note not found.");
}