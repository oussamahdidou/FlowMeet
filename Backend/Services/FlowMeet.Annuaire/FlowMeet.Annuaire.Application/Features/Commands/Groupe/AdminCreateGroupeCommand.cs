using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Groupe;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Commands.Groupe
{
    public class AdminCreateGroupeCommand : IRequest<Result<GroupeDTO>>
    {
        public string Label { get; set; }
        public bool Heritee { get; set; }
        public string EntiteId { get; set; }
    }
}
