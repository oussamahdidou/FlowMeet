using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Account;

namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserDto user);
    }
}
