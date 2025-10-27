namespace Contracts.Helpers
{
    public enum KafkaProducers
    {
        RoleCreatedProducer,
        RoleAssignedToGroupProducer,
        RoleRemovedFromGroupProducer,
        CollaborateurCreatedProducer,
        RoleAssignedToCollaborateurProducer,
        RoleRemovedFromCollaborateurProducer,
        GroupeAssignedToCollaborateurProducer,
        GroupeRemovedFromCollaborateurProducer
    }
}
