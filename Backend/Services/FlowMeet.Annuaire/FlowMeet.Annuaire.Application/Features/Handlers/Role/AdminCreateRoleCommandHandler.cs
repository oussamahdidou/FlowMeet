using Contracts.Events.Role;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Role;
using FlowMeet.Annuaire.Application.Features.DTOs.Role;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Role
{
    public class AdminCreateRoleCommandHandler : IRequestHandler<AdminCreateRoleCommand, Result<RoleDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<RoleCreatedEvent> publisher;
        public AdminCreateRoleCommandHandler(IUnitOfWork unitOfWork, IPublisher<RoleCreatedEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<RoleDTO>> Handle(AdminCreateRoleCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Role newRole = new Domain.Entities.Role
            {
                Label = request.Label,
                Heritee = request.Heritee,
                EntiteId = request.EntiteId
            };
            await unitOfWork.Roles.AddAsync(newRole);
            //publish event RoleCreatedEvent
            await publisher.PublishAsync(new RoleCreatedEvent(newRole.Id, newRole.Label));
            //commit transaction
            await unitOfWork.SaveChanges();
            return Result<RoleDTO>.Success(newRole.ToRoleDTO());
        }
    }
}
