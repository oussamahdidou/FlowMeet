using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Entite;
using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.ValueObjects;

namespace FlowMeet.Annuaire.Application.Features.Commands.Entite
{
    public class CreateEntiteCommand : IRequest<Result<EntiteDTO>>
    {
        public string Label { get; set; }
        public Adresse Adresse { get; set; }
        public string TypeEntiteId { get; set; }
        public string? ParentId { get; set; }
    }
}
