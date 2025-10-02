using FlowMeet.Notification.Application.Common.Requests;

namespace FlowMeet.Notification.Application.Common.Interfaces
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);

    }
}
