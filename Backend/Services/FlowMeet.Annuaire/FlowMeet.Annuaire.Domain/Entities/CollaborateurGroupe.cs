namespace FlowMeet.Annuaire.Domain.Entities
{
    public class CollaborateurGroupe
    {
        public string CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
        public string GroupeId { get; set; }
        public Groupe Groupe { get; set; }
    }
}
