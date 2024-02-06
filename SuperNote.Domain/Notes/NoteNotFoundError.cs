using SuperNote.Domain.Abstractions.ErrorHandling;

namespace SuperNote.Domain.Notes;

public class NoteNotFoundError : DomainError
{
    public NoteNotFoundError(string code, string message)
        : base(message, code)
    {        
        WithMetadata(nameof(ErrorType), ErrorType.NotFound);
    }
}