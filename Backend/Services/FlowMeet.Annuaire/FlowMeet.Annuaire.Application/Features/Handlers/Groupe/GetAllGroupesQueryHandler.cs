using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Groupe;
using FlowMeet.Annuaire.Application.Features.Queries.Groupe;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Groupe
{
    public class GetAllGroupesQueryHandler : IRequestHandler<GetAllGroupesQuery, Result<List<GroupeDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllGroupesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GroupeDTO>>> Handle(GetAllGroupesQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = new()
            {
                Filter = request.Filter,
                OrderBy = request.OrderBy,
                OrderByDescending = request.OrderByDescending,
                Skip = request.Skip,
                Take = request.Take
            };
            List<Domain.Entities.Groupe> groupes = await unitOfWork.Groupes.GetAllAsync(queryParameters);
            List<GroupeDTO> groupeDTOs = groupes.Select(g => new GroupeDTO
            {
                Id = g.Id,
                Label = g.Label,
                Heritee = g.Heritee,
                EntiteId = g.EntiteId
            }).ToList();
            return Result<List<GroupeDTO>>.Success(groupeDTOs);
        }


    }
}
