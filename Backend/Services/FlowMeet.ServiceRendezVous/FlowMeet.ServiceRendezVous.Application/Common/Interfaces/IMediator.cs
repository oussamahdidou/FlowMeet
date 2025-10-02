using FlowMeet.ServiceRendezVous.Application.Common.Requests;

namespace FlowMeet.ServiceRendezVous.Application.Common.Interfaces
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);

    }
}
