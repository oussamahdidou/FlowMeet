namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class RoleRendezVousType
    {
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public string RendezVousTypeId { get; set; }
        public RendezVousType RendezVousType { get; set; }
    }
}
