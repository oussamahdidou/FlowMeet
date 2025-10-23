using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Role;
using FlowMeet.Annuaire.Application.Features.Queries.Role;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Role
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, Result<List<RoleDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllRolesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<RoleDTO>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Role> roles = await unitOfWork.Roles.GetAllAsync(new QueryParameters
            {
                Filter = request.Filter,
                OrderBy = request.OrderBy,
                OrderByDescending = request.OrderByDescending,
                Skip = request.Skip,
                Take = request.Take
            });
            return Result<List<RoleDTO>>.Success(roles.Select(x => new RoleDTO
            {
                Id = x.Id,
                Label = x.Label,
                Heritee = x.Heritee,
                EntiteId = x.EntiteId,

            }).ToList());
        }
    }
}
