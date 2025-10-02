using FlowMeet.Annuaire.Application.Common.Requests;

namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);

    }
}
