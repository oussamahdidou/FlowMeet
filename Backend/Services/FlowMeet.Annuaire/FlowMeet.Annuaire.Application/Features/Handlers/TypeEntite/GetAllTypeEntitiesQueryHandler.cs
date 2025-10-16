using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.TypeEntite;
using FlowMeet.Annuaire.Application.Features.Queries;
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
            List<TypeEntiteDTO> typeEntites = await unitOfWork.TypeEntites.GetAsync(new QueryParameters<Domain.Entities.TypeEntite, TypeEntiteDTO>
            {
                Filter = request.Filter,
                OrderBy = request.OrderBy,
                OrderByDescending = request.OrderByDescending,
                Skip = request.Skip,
                Take = request.Take,
                Selector = e => new TypeEntiteDTO
                {
                    Id = e.Id,
                    Label = e.Label,
                    Level = e.Level
                }
            });
            return Result<List<TypeEntiteDTO>>.Success(typeEntites);
        }
    }
}
