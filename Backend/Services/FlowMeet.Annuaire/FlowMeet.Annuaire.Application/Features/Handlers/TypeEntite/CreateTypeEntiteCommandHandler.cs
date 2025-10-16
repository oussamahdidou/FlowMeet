using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.TypeEntite;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.TypeEntite;
using FlowMeet.Annuaire.Application.Features.Mappers;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.TypeEntite
{
    public class CreateTypeEntiteCommandHandler : IRequestHandler<CreateTypeEntiteCommand, Result<TypeEntiteDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateTypeEntiteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<TypeEntiteDTO>> Handle(CreateTypeEntiteCommand request, CancellationToken cancellationToken)
        {
            var typeEntite = new Domain.Entities.TypeEntite
            {
                Label = request.Label,
                Level = request.Level
            };
            bool isLevelExist = await unitOfWork.TypeEntites.IsLevelExistAsync(request.Level);
            if (isLevelExist)
            {
                return Result<TypeEntiteDTO>.Failure("Le niveau existe déjà.");
            }
            await unitOfWork.TypeEntites.AddAsync(typeEntite);
            await unitOfWork.SaveChanges();
            TypeEntiteDTO typeEntiteDTO = typeEntite.FromTypeEntiteToTypeEntiteDTO();
            return Result<TypeEntiteDTO>.Success(typeEntiteDTO);
        }
    }
}
