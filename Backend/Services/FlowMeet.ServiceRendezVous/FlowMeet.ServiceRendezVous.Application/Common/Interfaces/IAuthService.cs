using FlowMeet.ServiceRendezVous.Application.Features.DTOs.Responses.Account;

namespace FlowMeet.ServiceRendezVous.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserDto user);
    }
}
