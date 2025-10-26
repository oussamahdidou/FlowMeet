using FlowMeet.Annuaire.Application.Features.DTOs.Account;

namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserDto user);
    }
}
