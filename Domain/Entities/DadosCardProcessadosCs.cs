using System.Collections.Generic;

namespace Domain.Entities
{
    public class DadosCardProcessadosCs
    {
        public DadosCardProcessadosCs()
        {
            atencao = new AtencaoCs();
            atrasado = new AtrasadoCs();
            concluido = new ConcluidoCs();
        }

        public AtencaoCs atencao { get; set; }
        public AtrasadoCs atrasado { get; set; }
        public ConcluidoCs concluido { get; set; }

    }


    public class AtencaoCs
    {
        public AtencaoCs()
        {
            sol = new List<DadosCardCs>();
            fix = new List<DadosCardCs>();
            requerimento = new List<DadosCardCs>();
        }

        public List<DadosCardCs> sol { get; set; }
        public List<DadosCardCs> fix { get; set; }
        public List<DadosCardCs> requerimento { get; set; }

    }
    public class AtrasadoCs
    {
        public AtrasadoCs()
        {
            sol = new List<DadosCardCs>();
            fix = new List<DadosCardCs>();
            requerimento = new List<DadosCardCs>();
        }

        public List<DadosCardCs> sol { get; set; }
        public List<DadosCardCs> fix { get; set; }
        public List<DadosCardCs> requerimento { get; set; }
    }
    public class ConcluidoCs
    {
        public ConcluidoCs()
        {
            sol = new List<DadosCardCs>();
            fix = new List<DadosCardCs>();
            requerimento = new List<DadosCardCs>();
        }

        public List<DadosCardCs> sol { get; set; }
        public List<DadosCardCs> fix { get; set; }
        public List<DadosCardCs> requerimento { get; set; }
    }
}
