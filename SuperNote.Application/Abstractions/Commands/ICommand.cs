using MediatR;

namespace SuperNote.Application.Abstractions.Commands;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}