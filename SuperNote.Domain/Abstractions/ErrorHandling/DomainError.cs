using FluentResults;

namespace SuperNote.Domain.Abstractions.ErrorHandling;

public class DomainError : Error
{
    public const string ErrorCodeLiteral = "ErrorCode";
    
    protected DomainError(string message, string code) 
        : base(message)
    {
        WithMetadata(ErrorCodeLiteral, code);
    }
}