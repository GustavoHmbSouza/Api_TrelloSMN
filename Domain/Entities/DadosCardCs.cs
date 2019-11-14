using Domain.DadosTrello;
using Domain.Membro;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class DadosCardCs
    {
        IDadosQuadroDesenvRepository _dadosQuadroDesenvRepository;
        IMembroRepository _membroRepository;
        public DadosCardCs(IDadosQuadroDesenvRepository dadosQuadroDesenvRepository, IMembroRepository membroRepository)
        {
            _dadosQuadroDesenvRepository = dadosQuadroDesenvRepository;
            _membroRepository = membroRepository;
        }

        public string Id { get; set; }
        public string due { get; set; }
        public bool dueComplete { get; set; }
        public string desc { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string[] idMembers { get; set; }


        public DateTime Dat_Entrega { get; set; }
        public string Nom_DataEntregaFormatada { get; set; }
        public string Nom_Descricao { get; set; }
        public string Nom_Sigla { get; set; }
        public string Nom_Name { get; set; }
        public string Nom_Url { get; set; }
        public string Nom_Atrasado { get; set; }
        public BadgesCs badges { get; set; }
        public List<MembroCs> membros {get; set; }
        public Comentarios comentarios { get; set; }

        public void setDados()
        {
            setSiglaDescricao();
            Nom_Descricao = desc;
            Dat_Entrega = Convert.ToDateTime(due);
            Nom_DataEntregaFormatada = Dat_Entrega.ToString("g");
            Nom_Url = url;
            badges.setDados();
            membros = new List<MembroCs>();
            verificaData();
        }

        private void setSiglaDescricao()
        {
            string[] partes = name.Split('-');
            Nom_Sigla = partes[0] + '-' + partes[1];

            for (int i = 2; i < partes.Length; i++)
                Nom_Name += partes[i];
        }

        public void verificaData()
        {
            if(Dat_Entrega == Convert.ToDateTime("0001-01-01T00:00:00"))
            {
                return;
            }

            DateTime DataEntregaAux = Dat_Entrega;

            int diasAVerificar = Dat_Entrega.DayOfYear - DateTime.Now.DayOfYear;

            for(int i=0; i < diasAVerificar; i++)
            {
                if (DataEntregaAux.DayOfWeek == DayOfWeek.Saturday || DataEntregaAux.DayOfWeek == DayOfWeek.Sunday)
                {
                    Dat_Entrega = Dat_Entrega.AddDays(-1);
                }
                DataEntregaAux = DataEntregaAux.AddDays(-1);
            }

            if (dueComplete)
            {
                Nom_Atrasado = "Concluido";
            }
            else if(DateTime.Now.DayOfYear > Dat_Entrega.DayOfYear)
            {
                Nom_Atrasado = "Atrasado";
            }
            else if (Dat_Entrega.DayOfYear - DateTime.Now.DayOfYear >= 0 && Dat_Entrega.DayOfYear - DateTime.Now.DayOfYear < 3)
            {
                Nom_Atrasado = "Atencao";
            }
        }
    }
}
