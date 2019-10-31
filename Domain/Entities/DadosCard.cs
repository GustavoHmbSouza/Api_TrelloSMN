using System;

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


        public DateTime Dat_Entrega { get; set; }
        public string Nom_Descricao { get; set; }
        public string Nom_Sigla { get; set; }
        public string Nom_Name { get; set; }
        public string Nom_Url { get; set; }
        public Badges badges { get; set; }

        public void setDados()
        {
            setSiglaDescricao();
            Nom_Descricao = desc;
            Dat_Entrega = Convert.ToDateTime(due);
            Nom_Url = url;

            badges.setDados();
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
