using MediatR;

namespace SuperNote.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand> where TCommand : ICommand
{
}