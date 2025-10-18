namespace FlowMeet.Annuaire.Application.Features.DTOs.Responses.Entite
{
    public class EntiteHiearchieDTO
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string? ParentId { get; set; }
        public List<EntiteHiearchieDTO> Enfants { get; set; } = new List<EntiteHiearchieDTO>();
    }
}
