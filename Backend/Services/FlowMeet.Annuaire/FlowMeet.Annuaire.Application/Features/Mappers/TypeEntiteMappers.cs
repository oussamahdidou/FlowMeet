using FlowMeet.Annuaire.Application.Features.DTOs.TypeEntite;

namespace FlowMeet.Annuaire.Application.Features.Mappers
{
    public static class TypeEntiteMappers
    {
        public static TypeEntiteDTO FromTypeEntiteToTypeEntiteDTO(this Domain.Entities.TypeEntite typeEntite)
        {
            return new TypeEntiteDTO
            {
                Id = typeEntite.Id,
                Label = typeEntite.Label,
                Level = typeEntite.Level,

            };
        }
    }
}
