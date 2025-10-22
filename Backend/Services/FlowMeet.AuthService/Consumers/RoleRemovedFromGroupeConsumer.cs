using Contracts.Events.Groupe;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FlowMeet.AuthService.Consumers
{
    public class RoleRemovedFromGroupeConsumer : IMessageHandler<RoleRemovedFromGroupeEvent>
    {
        private readonly IServiceScopeFactory scopeFactory;
        public RoleRemovedFromGroupeConsumer(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public async Task Handle(IMessageContext context, RoleRemovedFromGroupeEvent message)
        {
            using var scope = scopeFactory.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            IdentityRole? role = await roleManager.FindByIdAsync(message.RoleId);
            if (role == null) throw new Exception("Role not found");

            var claim = new Claim("group", message.GroupeId);
            var result = await roleManager.RemoveClaimAsync(role, claim);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
