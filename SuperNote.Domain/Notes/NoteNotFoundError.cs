using SuperNote.Domain.SharedKernel.Errors;

namespace SuperNote.Domain.Notes;

public class NoteNotFoundError : DomainError
{
    public NoteNotFoundError()
        : base("Note not found.")
    {
        WithMetadata(nameof(ErrorType), ErrorType.NotFound);
    }
}