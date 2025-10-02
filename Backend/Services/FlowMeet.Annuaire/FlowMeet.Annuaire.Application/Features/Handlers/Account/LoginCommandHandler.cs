using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.Commands.Account;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Account;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Handlers.Account
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<UserDto>>
    {
        public Task<Result<UserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Result<UserDto>.Success(new UserDto
            {
                Email = "admin@gmail.com",
                Name = request.Username,
                Token = "e3637587536865853"
            }));

        }
    }
}
