using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Groupe;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Application.Features.Queries.Groupe;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Commands.Role
{
    public class GetEntiteGroupeQueryHandler : IRequestHandler<GetEntiteGroupeQuery, Result<List<GroupeDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetEntiteGroupeQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GroupeDTO>>> Handle(GetEntiteGroupeQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Groupe> groupes = await unitOfWork.Groupes.GroupeExistsInEntityOrParentsAsync(request.EntiteId, request.Parameters);
            return Result<List<GroupeDTO>>.Success(groupes.Select(x => x.FromGroupeToGroupeDTO()).ToList());
        }
    }
}
