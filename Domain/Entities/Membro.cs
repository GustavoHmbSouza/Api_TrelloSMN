namespace Domain.Entities
{
    public class Membro
    {
        public string avatarHash { get; set; }
        public string fullName { get; set; }
        public string id { get; set; }
        public string initials { get; set; }

        public string Nom_AvatarHash { get; set; }
        public string Nom_Nome { get; set; }
        public string Nom_Iniciais { get; set; }

        public void setDados()
        {
            Nom_AvatarHash = avatarHash;
            Nom_Nome = fullName;
            Nom_Iniciais = initials;
        }
    }
}
