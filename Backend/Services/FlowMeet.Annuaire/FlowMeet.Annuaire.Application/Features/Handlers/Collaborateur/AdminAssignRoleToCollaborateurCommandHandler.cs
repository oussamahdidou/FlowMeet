using Contracts.Events.Collaborateur;
using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Collaborateur
{
    public class AdminAssignRoleToCollaborateurCommandHandler : IRequestHandler<AdminAssignRoleToCollaborateurCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<RoleAssignedToCollaborateurEvent> publisher;
        public AdminAssignRoleToCollaborateurCommandHandler(IUnitOfWork unitOfWork, IPublisher<RoleAssignedToCollaborateurEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<Unit>> Handle(AdminAssignRoleToCollaborateurCommand request, CancellationToken cancellationToken)
        {
            var roleCollaborateurExist = await unitOfWork.CollaborateurRoles.ExistsAsync(request.CollaborateurId, request.RoleId);
            if (roleCollaborateurExist)
            {
                return Result<Unit>.Failure("Le rôle est déjà assigné à ce collaborateur.");
            }
            var collaborateurRole = new Domain.Entities.CollaborateurRole
            {
                CollaborateurId = request.CollaborateurId,
                RoleId = request.RoleId
            };
            await unitOfWork.CollaborateurRoles.AddAsync(collaborateurRole);
            //publish event RoleAssignedToCollaborateurEvent
            await publisher.PublishAsync(new RoleAssignedToCollaborateurEvent(request.CollaborateurId, request.RoleId));
            //commit transaction
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);


        }
    }
}
