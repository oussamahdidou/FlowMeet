using System.ComponentModel.DataAnnotations;

namespace FlowMeet.ServiceRendezVous.Domain.Entities
{
    public class Client
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public ICollection<RendezVous> RendezVous { get; set; }
    }
}
