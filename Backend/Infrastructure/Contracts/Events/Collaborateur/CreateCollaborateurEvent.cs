namespace Contracts.Events.Collaborateur
{
    public record CreateCollaborateurEvent(string Id, string UserName, string Email, string Telephone, string EntiteId, bool Active);
}
