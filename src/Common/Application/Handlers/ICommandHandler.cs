using Common.Application.Contracts;
using MediatR;

namespace Common.Application.Handlers;

public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
{
}