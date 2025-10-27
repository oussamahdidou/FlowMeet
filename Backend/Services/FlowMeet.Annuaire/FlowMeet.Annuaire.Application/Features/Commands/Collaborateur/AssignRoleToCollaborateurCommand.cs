using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Domain.Common;
using System.Text.Json.Serialization;

namespace FlowMeet.Annuaire.Application.Features.Commands.Collaborateur
{
    public class AssignRoleToCollaborateurCommand : IRequest<Result<Unit>>
    {
        public string CollaborateurId { get; set; }
        public string RoleId { get; set; }
        [JsonIgnore]
        public string? EntiteId { get; set; }
    }
}
