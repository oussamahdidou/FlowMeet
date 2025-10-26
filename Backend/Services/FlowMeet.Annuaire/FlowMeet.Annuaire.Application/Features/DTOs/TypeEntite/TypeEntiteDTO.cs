namespace FlowMeet.Annuaire.Application.Features.DTOs.TypeEntite
{
    public class TypeEntiteDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public int Level { get; set; }
    }
}
