using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeet.Annuaire.Domain.ValueObjects
{
    [ComplexType]
    public record Adresse(string Rue, string Ville, string CodePostal, string Pays);

}
