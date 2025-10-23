using Contracts.Events.Groupe;
using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Groupe
{
    public class AdminRemoveRoleFromGroupeCommandHandler : IRequestHandler<AdminRemoveRoleFromGroupeCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<RoleRemovedFromGroupeEvent> publisher;
        public AdminRemoveRoleFromGroupeCommandHandler(IUnitOfWork unitOfWork, IPublisher<RoleRemovedFromGroupeEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<Unit>> Handle(AdminRemoveRoleFromGroupeCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.GroupeRoles.DeleteAsync(new Domain.Entities.RoleGroupe
            {
                GroupeId = request.GroupeId,
                RoleId = request.RoleId
            });
            await publisher.PublishAsync(new RoleRemovedFromGroupeEvent(request.RoleId, request.GroupeId));
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
