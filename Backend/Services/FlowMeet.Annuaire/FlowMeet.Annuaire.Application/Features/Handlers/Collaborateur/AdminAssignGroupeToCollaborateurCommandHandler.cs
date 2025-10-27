using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Collaborateur
{
    public class AdminAssignGroupeToCollaborateurCommandHandler : IRequestHandler<AdminAssignGroupeToCollaborateurCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<GroupeAssignedToCollaborateurEvent> publisher;
        public AdminAssignGroupeToCollaborateurCommandHandler(IUnitOfWork unitOfWork, IPublisher<GroupeAssignedToCollaborateurEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<Unit>> Handle(AdminAssignGroupeToCollaborateurCommand request, CancellationToken cancellationToken)
        {
            var roleCollaborateurExist = await unitOfWork.CollaborateurGroupes.ExistsAsync(request.CollaborateurId, request.GroupeId);
            if (roleCollaborateurExist)
            {
                return Result<Unit>.Failure("Le groupe est déjà assigné à ce collaborateur.");
            }
            var collaborateurGroupe = new Domain.Entities.CollaborateurGroupe
            {
                CollaborateurId = request.CollaborateurId,
                GroupeId = request.GroupeId
            };
            await unitOfWork.CollaborateurGroupes.AddAsync(collaborateurGroupe);
            //publish event GroupeAssignedToCollaborateurEvent
            await publisher.PublishAsync(new GroupeAssignedToCollaborateurEvent(request.GroupeId, request.CollaborateurId));
            //commit transaction
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);


        }
    }
}
