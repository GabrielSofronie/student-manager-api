using Common.Application.Contracts;
using MediatR;

namespace Common.Application.Handlers;

public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
{
}