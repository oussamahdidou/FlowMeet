using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeet.Annuaire.Domain.Entities
{
    public class CollaborateurGroupe
    {
        public string CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
        public string GroupeId { get; set; }
        public Groupe Groupe { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
