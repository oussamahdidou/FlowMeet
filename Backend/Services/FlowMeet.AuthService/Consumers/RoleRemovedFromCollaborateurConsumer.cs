using Contracts.Events.Collaborateur;
using FlowMeet.AuthService.Data;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;

namespace FlowMeet.AuthService.Consumers
{
    public class RoleRemovedFromCollaborateurConsumer : IMessageHandler<RoleRemovedFromCollaborateurEvent>
    {
        private readonly IServiceScopeFactory serviceScope;
        public RoleRemovedFromCollaborateurConsumer(IServiceScopeFactory serviceScope)
        {
            this.serviceScope = serviceScope;
        }
        public async Task Handle(IMessageContext context, RoleRemovedFromCollaborateurEvent message)
        {
            using var scope = serviceScope.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            AppUser? appUser = await userManager.FindByIdAsync(message.CollaborateurId);
            if (appUser == null)
            {
                throw new Exception($"Collaborateur with ID {message.CollaborateurId} not found.");
            }
            IdentityRole? role = await roleManager.FindByIdAsync(message.RoleId);
            if (role == null)
            {
                throw new Exception($"Role with ID {message.RoleId} not found.");
            }
            var result = await userManager.RemoveFromRoleAsync(appUser, role.Name);
            if (result != null)
            {
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to remove role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
