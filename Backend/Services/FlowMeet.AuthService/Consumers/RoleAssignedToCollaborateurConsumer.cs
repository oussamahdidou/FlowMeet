using Contracts.Events.Collaborateur;
using FlowMeet.AuthService.Data;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;

namespace FlowMeet.AuthService.Consumers
{
    public class RoleAssignedToCollaborateurConsumer : IMessageHandler<RoleAssignedToCollaborateurEvent>
    {
        private readonly IServiceScopeFactory scopeFactory;
        public RoleAssignedToCollaborateurConsumer(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public async Task Handle(IMessageContext context, RoleAssignedToCollaborateurEvent message)
        {
            using var scope = scopeFactory.CreateScope();
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
            var result = await userManager.AddToRoleAsync(appUser, role.Name);
        }
    }
}
