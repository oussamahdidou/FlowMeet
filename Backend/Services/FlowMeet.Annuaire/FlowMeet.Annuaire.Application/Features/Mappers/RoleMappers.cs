using FlowMeet.Annuaire.Application.Features.Commands.Role;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Role;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Application.Features.Mappers
{
    public static class RoleMappers
    {
        public static RoleDTO ToRoleDTO(this Role role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                Label = role.Label,
                Heritee = role.Heritee,
                EntiteId = role.EntiteId
            };
        }
        public static Role FromCreateRoleCommandToRole(this CreateRoleCommand command)
        {
            return new Role
            {
                Label = command.Label,
                Heritee = command.Heritee,
                EntiteId = command.EntiteId
            };
        }
    }
}
