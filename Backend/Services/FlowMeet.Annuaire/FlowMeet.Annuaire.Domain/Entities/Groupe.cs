using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Annuaire.Domain.Entities
{
    public class Groupe
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public bool Heritee { get; set; }
        public string EntiteId { get; set; }
        public Entite Entite { get; set; }
        public ICollection<CollaborateurGroupe> CollaborateurGroupes { get; set; } = new List<CollaborateurGroupe>();
        public ICollection<RoleGroupe> RoleGroupes { get; set; } = new List<RoleGroupe>();
        public bool IsDeleted { get; set; } = false;

    }
}
