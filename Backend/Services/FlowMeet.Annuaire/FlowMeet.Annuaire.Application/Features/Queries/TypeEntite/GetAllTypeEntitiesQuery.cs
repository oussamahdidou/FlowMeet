using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.TypeEntite;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Queries.TypeEntite
{
    public class GetAllTypeEntitiesQuery : IRequest<Result<List<TypeEntiteDTO>>>
    {
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public bool OrderByDescending { get; set; } = false;
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
