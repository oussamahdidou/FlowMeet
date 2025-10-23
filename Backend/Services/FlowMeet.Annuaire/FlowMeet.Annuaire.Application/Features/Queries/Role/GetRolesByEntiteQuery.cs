using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Role;
using FlowMeet.Annuaire.Domain.Common;
using System.Text.Json.Serialization;

namespace FlowMeet.Annuaire.Application.Features.Queries.Role
{
    public class GetEntiteRolesQuery : IRequest<Result<List<RoleDTO>>>
    {
        public string EntiteId { get; set; }
        [JsonIgnore]
        public QueryParameters? Params { get; set; }
    }
}
