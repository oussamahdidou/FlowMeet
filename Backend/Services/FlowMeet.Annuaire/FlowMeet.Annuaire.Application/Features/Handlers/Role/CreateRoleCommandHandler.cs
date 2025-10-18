using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Role;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Role;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Role
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Result<RoleDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<RoleDTO>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Role newRole = request.FromCreateRoleCommandToRole();
            await unitOfWork.Roles.AddAsync(newRole);
            await unitOfWork.SaveChanges();
            return Result<RoleDTO>.Success(newRole.ToRoleDTO());
        }
    }
}
