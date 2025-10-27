using Contracts.Events.Collaborateur;
using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Collaborateur
{
    public class AdminRemoveRoleFromCollaborateurCommandHandler : IRequestHandler<AdminRemoveRoleFromCollaborateurCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<RoleRemovedFromCollaborateurEvent> publisher;
        public AdminRemoveRoleFromCollaborateurCommandHandler(IUnitOfWork unitOfWork, IPublisher<RoleRemovedFromCollaborateurEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }

        public async Task<Result<Unit>> Handle(AdminRemoveRoleFromCollaborateurCommand request, CancellationToken cancellationToken)
        {
            var roleCollaborateurExist = await unitOfWork.CollaborateurRoles.ExistsAsync(request.CollaborateurId, request.RoleId);
            if (!roleCollaborateurExist)
            {
                return Result<Unit>.Failure("Le rôle n'est pas assigné à ce collaborateur.");
            }
            var roleCollaborateur = await unitOfWork.CollaborateurRoles.GetByIdsAsync(request.CollaborateurId, request.RoleId);

            await unitOfWork.CollaborateurRoles.DeleteAsync(roleCollaborateur);
            //publish event RoleRemovedFromCollaborateurEvent
            await publisher.PublishAsync(new RoleRemovedFromCollaborateurEvent(request.CollaborateurId, request.RoleId));
            //commit transaction
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
