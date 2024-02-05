using MediatR;

namespace SuperNote.Application.Abstractions.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}