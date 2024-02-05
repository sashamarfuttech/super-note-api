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
        var errorType = GetErrorType(result.Errors.First());

        var statusCode = errorType switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var failures = ToValidationFailures(result.Errors);

        await ep.HttpContext.Response.SendErrorsAsync(
            failures,
            statusCode,
            cancellation: ct);

        static ErrorType GetErrorType(IError error)
        {
            var domainError = (DomainError)error;
            var type = (ErrorType)domainError.Metadata[nameof(ErrorType)];
            return type;
        }

        static List<ValidationFailure> ToValidationFailures(List<IError> errors)
            => errors.Select(e =>
            {
                var errorCode = e.Metadata[DomainError.ErrorCodeLiteral].ToString();
                return new ValidationFailure(errorCode, e.Message);
            }).ToList();
    }
}