namespace FlowMeet.Annuaire.Application.Features.DTOs.Responses.Groupe
{
    public class GroupeDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public bool Heritee { get; set; }
        public string EntiteId { get; set; }
    }
}
