using FluentResults;

namespace SuperNote.Domain.SharedKernel.Errors;

public class DomainError : Error
{
    protected DomainError(string message) 
        : base(message)
    {
    }
}