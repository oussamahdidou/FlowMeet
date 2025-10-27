using Contracts.Events.Collaborateur;
using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Collaborateur
{
    public class AssignGroupeToCollaborateurCommandHandler : IRequestHandler<AssignGroupeToCollaborateurCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<GroupeAssignedToCollaborateurEvent> publisher;
        public AssignGroupeToCollaborateurCommandHandler(IUnitOfWork unitOfWork, IPublisher<GroupeAssignedToCollaborateurEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<Unit>> Handle(AssignGroupeToCollaborateurCommand request, CancellationToken cancellationToken)
        {
            var roleCollaborateurExist = await unitOfWork.CollaborateurGroupes.ExistsAsync(request.CollaborateurId, request.GroupeId);
            if (roleCollaborateurExist)
            {
                return Result<Unit>.Failure("Le groupe est déjà assigné à ce collaborateur.");
            }
            var roleExistInEntite = await unitOfWork.Groupes.GroupeExistsInEntityOrParentsAsync(request.EntiteId, request.GroupeId);
            if (!roleExistInEntite)
            {
                return Result<Unit>.Failure("Le groupe n'existe pas dans l'entité spécifiée ou ses entités parentes.");
            }
            var collaborateurExistInEntite = await unitOfWork.Collaborateurs.ExistsInEntiteAsync(request.CollaborateurId, request.EntiteId);
            if (!collaborateurExistInEntite)
            {
                return Result<Unit>.Failure("Le collaborateur n'existe pas dans l'entité spécifiée.");
            }
            var collaborateurGroupe = new Domain.Entities.CollaborateurGroupe
            {
                CollaborateurId = request.CollaborateurId,
                GroupeId = request.GroupeId
            };
            await unitOfWork.CollaborateurGroupes.AddAsync(collaborateurGroupe);
            //publish event GroupeAssignedToCollaborateurEvent
            await publisher.PublishAsync(new GroupeAssignedToCollaborateurEvent(request.CollaborateurId, request.GroupeId));
            //commit transaction
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);


        }
    }
}
