using FlowMeet.Annuaire.Domain.ValueObjects;

namespace FlowMeet.Annuaire.Application.Features.DTOs.Responses.Entite
{
    public class EntiteDTO
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public Adresse Adresse { get; set; }
        public string TypeEntiteId { get; set; }
        public string? ParentId { get; set; }
    }
}
