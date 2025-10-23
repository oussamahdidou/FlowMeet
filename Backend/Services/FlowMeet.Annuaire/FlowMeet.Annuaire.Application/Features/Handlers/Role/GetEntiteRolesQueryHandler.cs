using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Role;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Application.Features.Queries.Role;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Role
{
    public class GetEntiteRolesQueryHandler : IRequestHandler<GetEntiteRolesQuery, Result<List<RoleDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetEntiteRolesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<RoleDTO>>> Handle(GetEntiteRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await unitOfWork.Roles.GetEntityAndInheritedRolesAsync(request.EntiteId, request.Params);
            return Result<List<RoleDTO>>.Success(roles.Select(x => x.ToRoleDTO()).ToList());
        }
    }
}
