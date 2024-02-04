using FastEndpoints;
using FluentResults;
using FluentValidation.Results;
using SuperNote.Domain.SharedKernel.Errors;

namespace SuperNote.WebApi.Extensions;

public static class ResponseExtensions
{
    public static async Task SendErrorResponse<T>(
        this IEndpoint ep,
        Result<T> result,
        CancellationToken ct)
    {
        if (result.IsSuccess)
        {
            throw new ArgumentException("The Result must be in a failed state.");
        }

        var domainError = (DomainError)result.Errors.First();

        var errorType = (ErrorType)domainError.Metadata[nameof(ErrorType)];

        var errors = new List<ValidationFailure>()
        {
            new(string.Empty, domainError.Message)
        };

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