using MediatR;

namespace SuperNote.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}