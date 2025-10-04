using System.ComponentModel.DataAnnotations;

namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class RendezVousType
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public TimeSpan Duree { get; set; }
        public ICollection<RendezVous> RendezVous { get; set; }
        public ICollection<RoleRendezVousType> RoleRendezVousTypes { get; set; }
        public ICollection<GroupeRendezVousType> GroupeRendezVousTypes { get; set; }
    }
}
