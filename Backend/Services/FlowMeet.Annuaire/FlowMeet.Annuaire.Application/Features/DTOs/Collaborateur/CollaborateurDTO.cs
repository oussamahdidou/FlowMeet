namespace FlowMeet.Annuaire.Application.Features.DTOs.Collaborateur
{
    public class CollaborateurDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string EntiteId { get; set; }
        public bool Active { get; set; }
    }
}
