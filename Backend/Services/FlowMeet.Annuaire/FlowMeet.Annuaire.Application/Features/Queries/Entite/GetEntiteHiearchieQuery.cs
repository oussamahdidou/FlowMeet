using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Entite;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Queries.Entite
{
    public class GetEntiteHiearchieQuery : IRequest<Result<EntiteHiearchieDTO>>
    {
        public string EntiteId { get; set; }
    }
}
