using FlowMeet.Annuaire.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Annuaire.Domain.Entities
{
    public class Entite
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public Adresse Adresse { get; set; }
        public string TypeEntiteId { get; set; }
        public TypeEntite TypeEntite { get; set; }
        public string? ParentId { get; set; }
        public Entite? Parent { get; set; }
        public ICollection<Entite> Enfants { get; set; } = new List<Entite>();
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Groupe> Groupes { get; set; } = new List<Groupe>();
        public bool IsDeleted { get; set; } = false;


    }
}
