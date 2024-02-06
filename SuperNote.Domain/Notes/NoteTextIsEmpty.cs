using SuperNote.Domain.Abstractions.ErrorHandling;

namespace SuperNote.Domain.Notes;

public class NoteTextIsEmptyError : DomainError
{
    public NoteTextIsEmptyError(string code, string message)
        : base(message, code)
    {        
        WithMetadata(nameof(ErrorType), ErrorType.InvalidData);
    }
}