using FlowMeet.Annuaire.Application.Common.Requests;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Account;
using FlowMeet.Annuaire.Domain.Common;

namespace FlowMeet.Annuaire.Application.Features.Commands.Account
{
    public class LoginCommand : IRequest<Result<UserDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
