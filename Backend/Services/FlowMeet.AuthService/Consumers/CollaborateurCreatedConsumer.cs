using Contracts.Events.Collaborateur;
using FlowMeet.AuthService.Data;
using KafkaFlow;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
namespace FlowMeet.AuthService.Consumers
{
    public class CollaborateurCreatedConsumer : IMessageHandler<CreateCollaborateurEvent>
    {
        private readonly IServiceScopeFactory scopeFactory;
        public CollaborateurCreatedConsumer(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public async Task Handle(IMessageContext context, CreateCollaborateurEvent message)
        {
            using var scope = scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var AppUser = new AppUser
            {
                Id = message.Id,
                UserName = message.UserName,
                Email = message.Email,
                PhoneNumber = message.Telephone,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var result = await userManager.CreateAsync(AppUser, "Coding@1234?");
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            await userManager.AddClaimsAsync(AppUser, new[]
            {
                new Claim("entiteId", message.EntiteId),
                new Claim("active", message.Active.ToString()),
            });
            await userManager.AddToRoleAsync(AppUser, "Collaborateur");
        }
    }
}
