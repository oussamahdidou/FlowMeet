using System.ComponentModel.DataAnnotations.Schema;

namespace FlowMeet.ServiceRendezVous.Domain.ValueObjects
{
    [ComplexType]
    public record Adresse(string Rue, string Ville, string CodePostal, string Pays);

}
