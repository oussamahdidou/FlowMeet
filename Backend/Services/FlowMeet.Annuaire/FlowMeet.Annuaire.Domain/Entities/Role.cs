using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Annuaire.Domain.Entities
{
    public class Role
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public bool Heritee { get; set; }
        public ICollection<CollaborateurRole> CollaborateurRoles { get; set; } = new List<CollaborateurRole>();
        public ICollection<RoleGroupe> RoleGroupes { get; set; } = new List<RoleGroupe>();
    }
}
