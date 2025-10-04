namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class GroupeRendezVousType
    {
        public string GroupeId { get; set; }
        public Groupe Groupe { get; set; }
        public string RendezVousTypeId { get; set; }
        public RendezVousType RendezVousType { get; set; }
    }
}
