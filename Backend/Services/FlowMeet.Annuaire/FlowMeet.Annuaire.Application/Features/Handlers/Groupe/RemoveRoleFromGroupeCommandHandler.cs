using Contracts.Events.Groupe;
using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Groupe
{
    public class RemoveRoleFromGroupeCommandHandler : IRequestHandler<RemoveRoleFromGroupeCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<RoleRemovedFromGroupeEvent> publisher;
        public RemoveRoleFromGroupeCommandHandler(IUnitOfWork unitOfWork, IPublisher<RoleRemovedFromGroupeEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<Unit>> Handle(RemoveRoleFromGroupeCommand request, CancellationToken cancellationToken)
        {
            bool IsgroupeInEntite = await unitOfWork.Groupes.GroupeExistsInEntiteAsync(request.GroupeId, request.EntiteId);
            if (!IsgroupeInEntite)
            {
                return Result<Unit>.Failure("Le groupe n'existe pas dans l'entité spécifiée.");
            }
            bool roleExists = await unitOfWork.Roles.RoleExistsInEntityOrParentsAsync(request.EntiteId, request.RoleId);
            if (!roleExists)
            {
                return Result<Unit>.Failure("Le rôle n'existe pas dans l'entité spécifiée ou ses entités parentes.");
            }
            RoleGroupe? existingRoleGroupe = await unitOfWork.GroupeRoles.GetRoleGroupeAsync(request.GroupeId, request.RoleId);
            if (existingRoleGroupe == null)
            {
                return Result<Unit>.Failure("Le rôle n'est pas assigné au groupe.");
            }
            await unitOfWork.GroupeRoles.DeleteAsync(existingRoleGroupe);
            await publisher.PublishAsync(new RoleRemovedFromGroupeEvent(request.RoleId, request.GroupeId));
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
