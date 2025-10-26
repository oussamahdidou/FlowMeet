using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Groupe;
using FlowMeet.Annuaire.Domain.Common;
using System.Text.Json.Serialization;

namespace FlowMeet.Annuaire.Application.Features.Commands.Groupe
{
    public class CreateGroupeCommand : IRequest<Result<GroupeDTO>>
    {
        public string Label { get; set; }
        public bool Heritee { get; set; }
        [JsonIgnore]
        public string? EntiteId { get; set; }
    }
}
