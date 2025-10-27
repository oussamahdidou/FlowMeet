using Contracts.Events.Collaborateur;
using FlowMeet.AuthService.Data;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;

namespace FlowMeet.AuthService.Consumers
{
    public class GroupeRemovedFromCollaborateurConsumer : IMessageHandler<GroupeRemovedFromCollaborateurEvent>
    {
        private readonly IServiceScopeFactory serviceScope;
        public GroupeRemovedFromCollaborateurConsumer(IServiceScopeFactory serviceScope)
        {
            this.serviceScope = serviceScope;
        }
        public async Task Handle(IMessageContext context, GroupeRemovedFromCollaborateurEvent message)
        {
            using var scope = serviceScope.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            AppUser? appUser = await userManager.FindByIdAsync(message.CollaborateurId);
            if (appUser == null)
            {
                throw new Exception($"Collaborateur with ID {message.CollaborateurId} not found.");
            }

            var result = await userManager.RemoveClaimAsync(appUser, new System.Security.Claims.Claim("group", message.GroupeId));
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
