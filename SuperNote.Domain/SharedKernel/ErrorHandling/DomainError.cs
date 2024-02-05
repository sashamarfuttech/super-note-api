using FluentResults;

namespace SuperNote.Domain.SharedKernel.ErrorHandling;

public class DomainError : Error
{
    public const string ErrorCodeLiteral = "ErrorCode";
    
    protected DomainError(string message, string code) 
        : base(message)
    {
        WithMetadata(ErrorCodeLiteral, code);
    }
}