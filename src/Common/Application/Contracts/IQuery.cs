using MediatR;

namespace Common.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult> { }