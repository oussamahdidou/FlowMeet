using FlowMeet.Annuaire.Application.Common;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Groupe
{
    public class AssignRoleToGroupeCommandHandler : IRequestHandler<AssignRoleToGroupeCommand, Result<Unit>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AssignRoleToGroupeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit>> Handle(AssignRoleToGroupeCommand request, CancellationToken cancellationToken)
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
            await unitOfWork.GroupeRoles.AddAsync(new Domain.Entities.RoleGroupe
            {
                GroupeId = request.GroupeId,
                RoleId = request.RoleId
            });
            await unitOfWork.SaveChanges();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
