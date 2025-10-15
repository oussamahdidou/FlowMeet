using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.TypeEntite;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Commands.TypeEntite
{
    public class CreateTypeEntiteCommand : IRequest<Result<TypeEntiteDTO>>
    {
        public string Label { get; set; }
        public int Level { get; set; }
    }
}
