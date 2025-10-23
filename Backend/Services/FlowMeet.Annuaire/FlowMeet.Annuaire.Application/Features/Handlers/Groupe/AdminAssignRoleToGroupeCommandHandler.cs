using Contracts.Events.Groupe;
using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Groupe
{
    public class AdminAssignRoleToGroupeCommandHandler : IRequestHandler<AdminAssignRoleToGroupeCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<RoleAssignedToGroupeEvent> publisher;
        public AdminAssignRoleToGroupeCommandHandler(IUnitOfWork unitOfWork, IPublisher<RoleAssignedToGroupeEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<Unit>> Handle(AdminAssignRoleToGroupeCommand request, CancellationToken cancellationToken)
        {


            await unitOfWork.GroupeRoles.AddAsync(new Domain.Entities.RoleGroupe
            {
                GroupeId = request.GroupeId,
                RoleId = request.RoleId
            });
            await publisher.PublishAsync(new RoleAssignedToGroupeEvent(request.RoleId, request.GroupeId));
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);

        }
    }
}
