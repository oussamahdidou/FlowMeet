using FlowMeet.ServiceRendezVous.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class Collaborateur
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public Adresse Adresse { get; set; }
        public ICollection<RendezVous> RendezVous { get; set; }
    }
}
