namespace FlowMeet.Annuaire.Domain.Entities
{
    public class CollaborateurRole
    {
        public string CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}
