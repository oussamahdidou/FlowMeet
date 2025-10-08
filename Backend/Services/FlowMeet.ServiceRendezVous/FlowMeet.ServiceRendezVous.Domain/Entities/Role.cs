using System.ComponentModel.DataAnnotations;

namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class Role
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public ICollection<RoleRendezVousType> RoleRendezVousTypes { get; set; }
        public string EntiteId { get; set; }
    }
}
