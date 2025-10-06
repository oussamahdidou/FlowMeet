namespace FlowMeet.Annuaire.Domain.Entities
{
    public class RoleGroupe
    {
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public string GroupeId { get; set; }
        public Groupe Groupe { get; set; }
    }
}
