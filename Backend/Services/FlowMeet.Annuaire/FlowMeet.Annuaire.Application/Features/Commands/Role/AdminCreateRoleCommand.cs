using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Role;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Commands.Role
{
    public class AdminCreateRoleCommand : IRequest<Result<RoleDTO>>
    {
        public string Label { get; set; }
        public bool Heritee { get; set; }
        public string EntiteId { get; set; }
    }
}
