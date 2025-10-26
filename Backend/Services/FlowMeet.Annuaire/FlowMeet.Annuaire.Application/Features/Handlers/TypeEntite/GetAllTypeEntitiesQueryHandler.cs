using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.TypeEntite;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Application.Features.Queries.TypeEntite;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.TypeEntite
{
    public class GetAllTypeEntitiesQueryHandler : IRequestHandler<GetAllTypeEntitiesQuery, Result<List<TypeEntiteDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllTypeEntitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<List<TypeEntiteDTO>>> Handle(GetAllTypeEntitiesQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.TypeEntite> typeEntites = await unitOfWork.TypeEntites.GetAllAsync(new QueryParameters
            {
                Filter = request.Filter,
                OrderBy = request.OrderBy,
                OrderByDescending = request.OrderByDescending,
                Skip = request.Skip,
                Take = request.Take,
            });
            List<TypeEntiteDTO> typeEntiteDTOs = typeEntites.Select(x => x.FromTypeEntiteToTypeEntiteDTO()).ToList();
            return Result<List<TypeEntiteDTO>>.Success(typeEntiteDTOs);
        }
    }
}
