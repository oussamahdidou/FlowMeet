using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Groupe;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Queries.Groupe
{
    public class GetAllGroupesQuery : IRequest<Result<List<GroupeDTO>>>
    {
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public bool OrderByDescending { get; set; } = false;
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
