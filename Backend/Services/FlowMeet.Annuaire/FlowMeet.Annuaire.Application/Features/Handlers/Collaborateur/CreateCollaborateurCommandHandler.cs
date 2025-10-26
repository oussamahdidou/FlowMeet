using Contracts.Events.Collaborateur;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using FlowMeet.Annuaire.Application.Features.DTOs.Collaborateur;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Collaborateur
{
    public class CreateCollaborateurCommandHandler : IRequestHandler<CreateCollaborateurCommand, Result<CollaborateurDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPublisher<CreateCollaborateurEvent> publisher;
        public CreateCollaborateurCommandHandler(IUnitOfWork unitOfWork, IPublisher<CreateCollaborateurEvent> publisher)
        {
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }
        public async Task<Result<CollaborateurDTO>> Handle(CreateCollaborateurCommand request, CancellationToken cancellationToken)
        {
            bool isUserNameExist = await unitOfWork.Collaborateurs.IsUserNameExistAsync(request.UserName);
            if (isUserNameExist)
            {
                return Result<CollaborateurDTO>.Failure("Le nom d'utilisateur existe déjà.");
            }
            bool isEmailExist = await unitOfWork.Collaborateurs.IsEmailExistAsync(request.Email);
            if (isEmailExist)
            {
                return Result<CollaborateurDTO>.Failure("L'email existe déjà.");
            }
            Domain.Entities.Collaborateur collaborateur = request.ToEntity();
            await unitOfWork.Collaborateurs.AddAsync(collaborateur);
            await publisher.PublishAsync(new CreateCollaborateurEvent(collaborateur.Id, collaborateur.UserName, collaborateur.Email, collaborateur.Telephone, collaborateur.EntiteId, collaborateur.Active));
            await unitOfWork.SaveChanges();
            CollaborateurDTO collaborateurDTO = collaborateur.ToDTO();
            return Result<CollaborateurDTO>.Success(collaborateurDTO);
        }
    }
}
