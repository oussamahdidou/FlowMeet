using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Groupe;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Groupe
{
    public class CreateGroupeCommandHandler : IRequestHandler<CreateGroupeCommand, Result<GroupeDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateGroupeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<GroupeDTO>> Handle(CreateGroupeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Groupe groupe = request.FromCreateGroupeCommandToGroupe();
            await unitOfWork.Groupes.AddAsync(groupe);
            await unitOfWork.SaveChanges();
            GroupeDTO groupeDTO = groupe.FromGroupeToGroupeDTO();
            return Result<GroupeDTO>.Success(groupeDTO);
        }
    }
}
