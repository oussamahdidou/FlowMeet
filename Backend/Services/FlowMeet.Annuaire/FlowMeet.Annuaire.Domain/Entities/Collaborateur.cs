using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Annuaire.Domain.Entities
{
    public class Collaborateur
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string EntiteId { get; set; }
        public Entite Entite { get; set; }
        public ICollection<CollaborateurRole> CollaborateurRoles { get; set; }
        public ICollection<CollaborateurGroupe> CollaborateurGroupes { get; set; }
        public bool Active { get; set; }

    }
}
