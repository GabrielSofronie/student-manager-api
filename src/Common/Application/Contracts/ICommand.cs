using MediatR;

namespace Common.Application.Contracts;

public interface ICommand<out TResult> : IRequest<TResult> { }