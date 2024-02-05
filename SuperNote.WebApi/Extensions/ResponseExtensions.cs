using FastEndpoints;
using FluentResults;
using FluentValidation.Results;
using SuperNote.Domain.SharedKernel.ErrorHandling;

namespace SuperNote.WebApi.Extensions;

public static class ResponseExtensions
{
    public static async Task SendProblemDetailsResponse<T>(
        this IEndpoint ep,
        Result<T> result,
        CancellationToken ct)
    {
        var domainError = (DomainError)result.Errors.First();

        var errorCode = (string)domainError.Metadata[DomainError.ErrorCodeLiteral];

        var errors = new List<ValidationFailure>()
        {
            new(errorCode, domainError.Message)
        };
        
        var errorType = (ErrorType)domainError.Metadata[nameof(ErrorType)];

        var statusCode = errorType switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        await ep.HttpContext.Response.SendErrorsAsync(
            errors,
            statusCode,
            cancellation: ct);
    }
}