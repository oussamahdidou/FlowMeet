using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Entite;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Application.Features.Queries.Entite;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Entite
{
    public class GetEntiteHiearchieQueryHandler : IRequestHandler<GetEntiteHiearchieQuery, Result<EntiteHiearchieDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetEntiteHiearchieQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        async Task<Result<EntiteHiearchieDTO>> IRequestHandler<GetEntiteHiearchieQuery, Result<EntiteHiearchieDTO>>.Handle(GetEntiteHiearchieQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Entite? entite = await unitOfWork.Entites.GetEntiteHiearchyAsync(request.EntiteId);
            if (entite == null)
            {
                return Result<EntiteHiearchieDTO>.Failure("Entité non trouvée.");
            }
            return Result<EntiteHiearchieDTO>.Success(entite.FromEntiteToHiearchyDTO());
        }
    }
}
