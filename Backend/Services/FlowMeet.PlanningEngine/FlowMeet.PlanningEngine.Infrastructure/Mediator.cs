using FlowMeet.PlanningEngine.Application.Common.Interfaces;
using FlowMeet.PlanningEngine.Application.Common.Requests;

namespace FlowMeet.PlanningEngine.Infrastructure
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for {request.GetType().Name} not found.");
            }

            var method = handlerType.GetMethod("Handle");
            return await (Task<TResponse>)method.Invoke(handler, [request, CancellationToken.None]);
        }
    }
}
