using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Groupe;
using FlowMeet.Annuaire.Domain.Common;
using System.Text.Json.Serialization;

namespace FlowMeet.Annuaire.Application.Features.Queries.Groupe
{
    public class GetEntiteGroupeQuery : IRequest<Result<List<GroupeDTO>>>
    {
        public string EntiteId { get; set; }
        [JsonIgnore]
        public QueryParameters? Parameters { get; set; }

    }
}
