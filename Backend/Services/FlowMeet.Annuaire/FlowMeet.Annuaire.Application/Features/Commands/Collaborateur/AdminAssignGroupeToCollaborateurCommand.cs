using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Commands.Collaborateur
{
    public class AdminAssignGroupeToCollaborateurCommand : IRequest<Result<Unit>>
    {
        public string CollaborateurId { get; set; }
        public string GroupeId { get; set; }

    }
}
