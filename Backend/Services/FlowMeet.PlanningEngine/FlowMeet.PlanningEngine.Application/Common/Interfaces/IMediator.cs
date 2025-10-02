using FlowMeet.PlanningEngine.Application.Common.Requests;

namespace FlowMeet.PlanningEngine.Application.Common.Interfaces
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);

    }
}
