using FlowMeet.Notification.Domain.Common;
using FlowMeet.PlanningEngine.Application.Common.Requests;
using FlowMeet.PlanningEngine.Application.Features.DTOs.Responses.Account;

namespace FlowMeet.PlanningEngine.Application.Features.Commands.Account
{
    public class LoginCommand : IRequest<Result<UserDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
