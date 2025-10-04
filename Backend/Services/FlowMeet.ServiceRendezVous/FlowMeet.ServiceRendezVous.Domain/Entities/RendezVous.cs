using FlowMeet.ServiceRendezVous.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class RendezVous
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Date { get; set; }
        public RendezVousStatus Status { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string RendezVousTypeId { get; set; }
        public RendezVousType RendezVousType { get; set; }
        public string CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
    }
}
