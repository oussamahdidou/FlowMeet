using Contracts.Events.Collaborateur;
using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Collaborateur
{
    public class AssignRoleToCollaborateurCommandHandler : IRequestHandler<AssignRoleToCollaborateurCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<RoleAssignedToCollaborateurEvent> publisher;
        public AssignRoleToCollaborateurCommandHandler(IUnitOfWork unitOfWork, IPublisher<RoleAssignedToCollaborateurEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<Unit>> Handle(AssignRoleToCollaborateurCommand request, CancellationToken cancellationToken)
        {
            var roleCollaborateurExist = await unitOfWork.CollaborateurRoles.ExistsAsync(request.CollaborateurId, request.RoleId);
            if (roleCollaborateurExist)
            {
                return Result<Unit>.Failure("Le rôle est déjà assigné à ce collaborateur.");
            }
            var roleExistInEntite = await unitOfWork.Roles.RoleExistsInEntityOrParentsAsync(request.EntiteId, request.RoleId);
            if (!roleExistInEntite)
            {
                return Result<Unit>.Failure("Le rôle n'existe pas dans l'entité spécifiée ou ses entités parentes.");
            }
            var collaborateurExistInEntite = await unitOfWork.Collaborateurs.ExistsInEntiteAsync(request.CollaborateurId, request.EntiteId);
            if (!collaborateurExistInEntite)
            {
                return Result<Unit>.Failure("Le collaborateur n'existe pas dans l'entité spécifiée.");
            }
            var collaborateurRole = new Domain.Entities.CollaborateurRole
            {
                CollaborateurId = request.CollaborateurId,
                RoleId = request.RoleId
            };
            await unitOfWork.CollaborateurRoles.AddAsync(collaborateurRole);
            //publish event RoleAssignedToCollaborateurEvent
            await publisher.PublishAsync(new RoleAssignedToCollaborateurEvent(request.RoleId, request.CollaborateurId));
            //commit transaction
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);


        }
    }
}
