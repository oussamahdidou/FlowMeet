using System.ComponentModel.DataAnnotations;

namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class Groupe
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public ICollection<GroupeRendezVousType> GroupeRendezVousTypes { get; set; }
    }
}
