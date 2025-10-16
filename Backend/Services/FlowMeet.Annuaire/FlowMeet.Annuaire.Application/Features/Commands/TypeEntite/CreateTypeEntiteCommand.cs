using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.TypeEntite;
using FlowMeet.Annuaire.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace FlowMeet.Annuaire.Application.Features.Commands.TypeEntite
{
    public class CreateTypeEntiteCommand : IRequest<Result<TypeEntiteDTO>>
    {
        public string Label { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than 0.")]
        public int Level { get; set; }
    }
}
