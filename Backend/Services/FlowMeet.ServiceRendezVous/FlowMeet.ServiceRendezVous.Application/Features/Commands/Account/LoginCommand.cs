using FlowMeet.ServiceRendezVous.Application.Common.Requests;
using FlowMeet.ServiceRendezVous.Application.Features.DTOs.Responses.Account;
using FlowMeet.ServiceRendezVous.Domain.Common;

namespace FlowMeet.ServiceRendezVous.Application.Features.Commands.Account
{
    public class LoginCommand : IRequest<Result<UserDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
