using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Features.GenericTasks.Commands.DeleteGenericTask;

namespace TaskManagement.Application.Behaviors
{
    public class UnHandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<DeleteGenericTaskCommandHandler> _logger;

        public UnHandledExceptionBehavior(ILogger<DeleteGenericTaskCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "An exception occurred for the request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
