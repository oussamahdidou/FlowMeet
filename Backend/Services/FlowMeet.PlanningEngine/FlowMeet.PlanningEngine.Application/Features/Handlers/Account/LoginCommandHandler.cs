using FlowMeet.Notification.Domain.Common;
using FlowMeet.PlanningEngine.Application.Common.Requests;
using FlowMeet.PlanningEngine.Application.Features.Commands.Account;
using FlowMeet.PlanningEngine.Application.Features.DTOs.Responses.Account;

namespace FlowMeet.PlanningEngine.Application.Features.Handlers.Account
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
