using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Domain.Common;
using System.Text.Json.Serialization;

namespace FlowMeet.Annuaire.Application.Features.Commands.Collaborateur
{
    public class RemoveGroupeFromCollaborateurCommand : IRequest<Result<Unit>>
    {
        public string CollaborateurId { get; set; }
        public string GroupeId { get; set; }
        [JsonIgnore]
        public string? EntiteId { get; set; }
    }
}
