using System.Collections.Generic;

namespace Domain.Entities
{
    public class DadosCardProcessadosCs
    {
        public DadosCardProcessadosCs()
        {
            atencao = new DadosCategoria();
            atrasado = new DadosCategoria();
            concluido = new DadosCategoria();
            previsto = new DadosCategoria();
        }

        public DadosCategoria atencao { get; set; }
        public DadosCategoria atrasado { get; set; }
        public DadosCategoria concluido { get; set; }
        public DadosCategoria previsto { get; set; }
    }


    public class DadosCategoria
    {
        public DadosCategoria()
        {
            sol = new List<DadosCardCs>();
            fix = new List<DadosCardCs>();
            requerimento = new List<DadosCardCs>();

            qtdSol = new DadosQuantidade();
            qtdFix = new DadosQuantidade();
            qtdRequerimento = new DadosQuantidade();
        }

        public List<DadosCardCs> sol { get; set; }
        public List<DadosCardCs> fix { get; set; }
        public List<DadosCardCs> requerimento { get; set; }

        public DadosQuantidade qtdSol { get; set; }
        public DadosQuantidade qtdFix { get; set; }
        public DadosQuantidade qtdRequerimento { get; set; }

    }

    public class DadosQuantidade
    {
        public DadosQuantidade()
        {
            qtdTotal = 0;
            qtdHorasTotal = 0;
            qtdHorasConcluido = 0;
            qtdHorasPrevisto = 0;
        }
        public int qtdTotal { get; set; }
        public int qtdHorasTotal { get; set; }
        public double qtdHorasConcluido { get; set; }
        public double qtdHorasPrevisto { get; set; }
    }
}
