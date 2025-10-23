using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Commands.Groupe
{
    public class AdminAssignRoleToGroupeCommand : IRequest<Result<Unit>>
    {
        public string GroupeId { get; set; }
        public string RoleId { get; set; }

    }
}
