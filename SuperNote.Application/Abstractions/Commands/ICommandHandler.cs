using MediatR;

namespace SuperNote.Application.Abstractions.Commands;

public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand> where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
{
}