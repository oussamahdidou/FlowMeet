using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Entite;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Application.Features.Queries.TypeEntite;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Entite
{
    public class GetRootEntiteHiearchieQueryHandler : IRequestHandler<GetRootEntiteHiearchieQuery, Result<EntiteHiearchieDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetRootEntiteHiearchieQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<EntiteHiearchieDTO>> Handle(GetRootEntiteHiearchieQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Entite? entite = await unitOfWork.Entites.GetRootEntiteHiearchyAsync();
            if (entite == null)
            {
                return Result<EntiteHiearchieDTO>.Failure("Entité racine non trouvée.");
            }
            return Result<EntiteHiearchieDTO>.Success(entite.FromEntiteToHiearchyDTO());
        }
    }
}
