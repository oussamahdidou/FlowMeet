using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Domain.Common;
using System.Text.Json.Serialization;

namespace FlowMeet.Annuaire.Application.Features.Commands.Groupe
{
    public class AssignRoleToGroupeCommand : IRequest<Result<Unit>>
    {
        public string GroupeId { get; set; }
        public string RoleId { get; set; }
        [JsonIgnore]
        public string? EntiteId { get; set; }
    }
}
