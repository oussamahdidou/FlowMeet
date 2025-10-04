using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Annuaire.Domain.Entities
{
    public class TypeEntite
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public int Level { get; set; }
        public ICollection<Entite> Entites { get; set; } = new List<Entite>();
    }
}
