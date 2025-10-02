using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Application.Common.Requests;

namespace FlowMeet.ServiceRendezVous.Infrastructure
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = serviceProvider.GetService(handlerType);

            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for {request.GetType().Name} not found.");
            }

            var method = handlerType.GetMethod("Handle");
            return await (Task<TResponse>)method.Invoke(handler, [request, CancellationToken.None]);
        }
    }
}
