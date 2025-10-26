using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Collaborateur;
using FlowMeet.Annuaire.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlowMeet.Annuaire.Application.Features.Commands.Collaborateur
{
    public class CreateCollaborateurCommand : IRequest<Result<CollaborateurDTO>>
    {
        public string UserName { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Telephone { get; set; }
        [JsonIgnore]
        public string? EntiteId { get; set; }
    }
}
