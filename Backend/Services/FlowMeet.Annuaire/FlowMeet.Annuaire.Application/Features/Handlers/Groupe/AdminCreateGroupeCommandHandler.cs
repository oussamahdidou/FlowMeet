using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Groupe;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Groupe
{
    public class AdminCreateGroupeCommandHandler : IRequestHandler<AdminCreateGroupeCommand, Result<GroupeDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminCreateGroupeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<GroupeDTO>> Handle(AdminCreateGroupeCommand request, CancellationToken cancellationToken)
        {
            var groupe = new Domain.Entities.Groupe
            {
                Label = request.Label,
                Heritee = request.Heritee,
                EntiteId = request.EntiteId
            };
            await unitOfWork.Groupes.AddAsync(groupe);
            await unitOfWork.SaveChanges();
            return Result<GroupeDTO>.Success(groupe.FromGroupeToGroupeDTO());
        }
    }
}
