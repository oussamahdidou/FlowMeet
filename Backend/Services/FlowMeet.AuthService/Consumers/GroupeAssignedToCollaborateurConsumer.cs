using Contracts.Events.Collaborateur;
using FlowMeet.AuthService.Data;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;

namespace FlowMeet.AuthService.Consumers
{
    public class GroupeAssignedToCollaborateurConsumer : IMessageHandler<GroupeAssignedToCollaborateurEvent>
    {
        private readonly IServiceScopeFactory scopeFactory;
        public GroupeAssignedToCollaborateurConsumer(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public async Task Handle(IMessageContext context, GroupeAssignedToCollaborateurEvent message)
        {
            using var scope = scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            AppUser? appUser = await userManager.FindByIdAsync(message.CollaborateurId);
            if (appUser == null)
            {
                throw new Exception($"Collaborateur with ID {message.CollaborateurId} not found.");
            }

            var result = await userManager.AddClaimAsync(appUser, new System.Security.Claims.Claim("group", message.GroupeId));
        }
    }
}
