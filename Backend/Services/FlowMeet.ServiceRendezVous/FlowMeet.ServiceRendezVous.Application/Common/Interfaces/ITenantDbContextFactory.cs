namespace FlowMeet.ServiceRendezVous.Application.Common.Interfaces
{
    public interface ITenantDbContextFactory<TContext> where TContext : class
    {
        TContext CreateTenantDbContext();
        TContext CreateTenantDbcontext(string tenantId);
    }
}
