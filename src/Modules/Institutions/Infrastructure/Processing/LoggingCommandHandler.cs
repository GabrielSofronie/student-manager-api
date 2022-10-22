using Common.Application.Contracts;
using Common.Application.Handlers;
using Microsoft.Extensions.Logging;

namespace Institutions.Infrastructure.Processing;

internal class LoggingCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly ILogger _logger;
    private readonly ICommandHandler<TCommand, TResult> _handler;

    public LoggingCommandHandler(ILogger logger, ICommandHandler<TCommand, TResult> handler)
    {
        _logger = logger;
        _handler = handler;
    }

    public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var cmdName = request.GetType().Name;

        try
        {
            _logger.LogInformation($"Executing command {cmdName} processed.");
            var result = await _handler.Handle(request, cancellationToken);
            _logger.LogInformation($"Command {cmdName} processed successfully.");

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError($"Command {cmdName} failed.", exception);
            throw;
        }
    }
}