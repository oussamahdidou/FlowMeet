using FlowMeet.Notification.Application.Common.Requests;
using FlowMeet.Notification.Application.Features.DTOs.Responses.Account;
using FlowMeet.Notification.Domain.Common;

namespace FlowMeet.Notification.Application.Features.Commands.Account
{
    public class LoginCommand : IRequest<Result<UserDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
