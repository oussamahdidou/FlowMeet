using FlowMeet.Notification.Application.Features.DTOs.Responses.Account;

namespace FlowMeet.Notification.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<string> CreateToken(UserDto user);
    }
}
