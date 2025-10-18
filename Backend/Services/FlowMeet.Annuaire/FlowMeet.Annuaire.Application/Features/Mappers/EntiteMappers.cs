using FlowMeet.Annuaire.Application.Features.Commands.Entite;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Entite;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Application.Features.Mappers
{
    public static class EntiteMappers
    {

        public static Entite FromCreateEntiteCommandToEntite(this CreateEntiteCommand entite)
        {
            return new Entite
            {
                Label = entite.Label,
                TypeEntiteId = entite.TypeEntiteId,
                ParentId = entite.ParentId,
                Adresse = entite.Adresse,

            };
        }
        public static EntiteDTO FromEntiteToEntiteDTO(this Entite entite)
        {
            return new EntiteDTO
            {
                Id = entite.Id,
                Label = entite.Label,
                TypeEntiteId = entite.TypeEntiteId,
                ParentId = entite.ParentId,
                Adresse = entite.Adresse,
            };
        }
        public static EntiteHiearchieDTO FromEntiteToHiearchyDTO(this Entite entite)
        {
            return new EntiteHiearchieDTO
            {
                Id = entite.Id,
                Label = entite.Label,
                ParentId = entite.ParentId,
                Enfants = entite.Enfants.Select(e => e.FromEntiteToHiearchyDTO()).ToList()
            };
        }
    }
}
