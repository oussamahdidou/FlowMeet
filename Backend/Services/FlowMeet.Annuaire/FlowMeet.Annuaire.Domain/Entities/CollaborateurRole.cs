using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeet.Annuaire.Domain.Entities
{
    public class CollaborateurRole
    {
        public string CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
