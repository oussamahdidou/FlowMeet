using Contracts.Events.Role;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;

namespace FlowMeet.AuthService.Consumers
{
    public class RoleCreatedHandler : IMessageHandler<RoleCreatedEvent>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RoleCreatedHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task Handle(IMessageContext context, RoleCreatedEvent message)
        {
            using var scope = _scopeFactory.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleExists = await roleManager.RoleExistsAsync(message.Label);
            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Id = message.Id,
                    Name = message.Label,
                    NormalizedName = message.Label.ToUpperInvariant()
                };
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
