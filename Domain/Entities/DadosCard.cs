namespace Domain.Entities
{
    public class DadosCard
    {
        public string Id { get; set; }

        public string due { get; set; }

        public string desc { get; set; }

        public string name { get; set; }

        public string url { get; set; }

        public string [] idMembers { get; set; }

        
        public string Nom_Sigla { get; set; }
        public string Nom_Name { get; set; }


        public void setDados()
        {
            setSiglaDescricao();
        }

        private void setSiglaDescricao()
        {
            string[] partes = name.Split('-');
            Nom_Sigla = partes[0];

            for (int i = 1; i != partes.Length; i++)
                Nom_Name += partes[i];
        }
    }
}
