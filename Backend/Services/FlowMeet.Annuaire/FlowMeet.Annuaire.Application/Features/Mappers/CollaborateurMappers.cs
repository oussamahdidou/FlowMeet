using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Application.Features.DTOs.Collaborateur;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Application.Features.Mappers
{
    public static class CollaborateurMappers
    {
        public static CollaborateurDTO ToDTO(this Collaborateur collaborateur)
        {
            return new CollaborateurDTO
            {
                Id = collaborateur.Id,
                UserName = collaborateur.UserName,
                Nom = collaborateur.Nom,
                Prenom = collaborateur.Prenom,
                Email = collaborateur.Email,
                Telephone = collaborateur.Telephone,
                EntiteId = collaborateur.EntiteId,
                Active = collaborateur.Active
            };
        }
        public static Collaborateur ToEntity(this CreateCollaborateurCommand command)
        {
            return new Collaborateur
            {
                UserName = command.UserName,
                Nom = command.Nom,
                Prenom = command.Prenom,
                Email = command.Email,
                Telephone = command.Telephone,
                EntiteId = command.EntiteId,
                Active = true,
            };
        }
    }
}
