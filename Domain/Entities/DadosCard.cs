﻿using System;

namespace Domain.Entities
{
    public class DadosCard
    {
        public string Id { get; set; }
        public string due { get; set; }
        public bool dueComplete { get; set; }
        public string desc { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string[] idMembers { get; set; }


        public DateTime Dat_Entrega { get; set; }
        public string Nom_Descricao { get; set; }
        public string Nom_Sigla { get; set; }
        public string Nom_Name { get; set; }
        public string Nom_Url { get; set; }
        public string Nom_Atrasado { get; set; }
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

        public bool verificaData()
        {
            if (dueComplete)
            {
                Nom_Atrasado = "Concluido";
                return true;
            }
            else if(DateTime.Now.DayOfYear > Dat_Entrega.DayOfYear && Dat_Entrega != Convert.ToDateTime("0001-01-01T00:00:00"))
            {
                Nom_Atrasado = "Atrasado";
                return true;
            }
            else if (Dat_Entrega.DayOfYear - DateTime.Now.DayOfYear >= 0 && Dat_Entrega.DayOfYear - DateTime.Now.DayOfYear < 3)
            {
                Nom_Atrasado = "Atenção";
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
