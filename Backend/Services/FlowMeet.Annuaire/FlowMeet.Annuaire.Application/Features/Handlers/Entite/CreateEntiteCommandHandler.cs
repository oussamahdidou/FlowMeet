using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Entite;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Entite;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Entite
{
    public class CreateEntiteCommandHandler : IRequestHandler<CreateEntiteCommand, Result<EntiteDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateEntiteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<EntiteDTO>> Handle(CreateEntiteCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.TypeEntite? typeEntite = await unitOfWork.TypeEntites.GetByIdAsync(request.TypeEntiteId);
            if (typeEntite == null)
            {
                return Result<EntiteDTO>.Failure($"Type d'entité avec l'ID {request.TypeEntiteId} n'existe pas.");
            }
            if (request.ParentId != null)
            {
                Domain.Entities.Entite? parentEntite = await unitOfWork.Entites.GetByIdAsync(request.ParentId);
                if (parentEntite == null)
                {
                    return Result<EntiteDTO>.Failure($"Entité parente avec l'ID {request.ParentId} n'existe pas.");
                }
                if (parentEntite.TypeEntite.Level + 1 != typeEntite.Level)
                {
                    return Result<EntiteDTO>.Failure($"L'entité parente spécifiée n'est pas située au niveau hiérarchique directement supérieur à l'entité enfant (niveau R+1 attendu).");

                }
            }

            Domain.Entities.Entite entite = request.FromCreateEntiteCommandToEntite();
            await unitOfWork.Entites.AddAsync(entite);
            await unitOfWork.SaveChanges();
            return Result<EntiteDTO>.Success(entite.FromEntiteToEntiteDTO());
        }
    }
}
