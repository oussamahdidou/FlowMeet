using Contracts.Events.Groupe;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FlowMeet.AuthService.Consumers
{
    public class RoleAssignedToGroupeConsumer : IMessageHandler<RoleAssignedToGroupeEvent>
    {
        private readonly IServiceScopeFactory scopeFactory;
        public RoleAssignedToGroupeConsumer(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public async Task Handle(IMessageContext context, RoleAssignedToGroupeEvent message)
        {
            using var scope = scopeFactory.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            IdentityRole? role = await roleManager.FindByIdAsync(message.RoleId);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {message.RoleId} not found.");
            }
            var result = await roleManager.AddClaimAsync(role, new Claim("group", message.groupeId));
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

    }
}
