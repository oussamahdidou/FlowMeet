using FlowMeet.ServiceRendezVous.Application.Common.Requests;
using FlowMeet.ServiceRendezVous.Application.Features.Commands.Account;
using FlowMeet.ServiceRendezVous.Application.Features.DTOs.Responses.Account;
using FlowMeet.ServiceRendezVous.Domain.Common;

namespace FlowMeet.ServiceRendezVous.Application.Features.Handlers.Account
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
