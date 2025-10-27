using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Collaborateur
{
    public class AdminRemoveGroupeFromCollaborateurCommandHandler : IRequestHandler<AdminRemoveGroupeFromCollaborateurCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<GroupeRemovedFromCollaborateurEvent> publisher;
        public AdminRemoveGroupeFromCollaborateurCommandHandler(IUnitOfWork unitOfWork, IPublisher<GroupeRemovedFromCollaborateurEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }

        public async Task<Result<Unit>> Handle(AdminRemoveGroupeFromCollaborateurCommand request, CancellationToken cancellationToken)
        {
            var roleCollaborateurExist = await unitOfWork.CollaborateurGroupes.ExistsAsync(request.CollaborateurId, request.GroupeId);
            if (!roleCollaborateurExist)
            {
                return Result<Unit>.Failure("Le groupe n'est pas assigné à ce collaborateur.");
            }
            var roleCollaborateur = await unitOfWork.CollaborateurGroupes.GetByIdsAsync(request.CollaborateurId, request.GroupeId);

            await unitOfWork.CollaborateurGroupes.DeleteAsync(roleCollaborateur);
            //publish event GroupeRemovedFromCollaborateurEvent
            await publisher.PublishAsync(new GroupeRemovedFromCollaborateurEvent(request.GroupeId, request.CollaborateurId));
            //commit transaction
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
