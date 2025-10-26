using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Application.Features.DTOs.Groupe;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Application.Features.Mappers
{
    public static class GroupeMappers
    {
        public static Groupe FromCreateGroupeCommandToGroupe(this CreateGroupeCommand command)
        {
            return new Groupe
            {
                Label = command.Label,
                Heritee = command.Heritee,
                EntiteId = command.EntiteId
            };
        }
        public static GroupeDTO FromGroupeToGroupeDTO(this Groupe groupe)
        {
            return new GroupeDTO
            {
                Id = groupe.Id,
                Label = groupe.Label,
                Heritee = groupe.Heritee,
                EntiteId = groupe.EntiteId
            };
        }
    }
}
