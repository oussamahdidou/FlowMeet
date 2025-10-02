using FlowMeet.PlanningEngine.Application.Features.DTOs.Responses.Account;

namespace FlowMeet.PlanningEngine.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserDto user);
    }
}
