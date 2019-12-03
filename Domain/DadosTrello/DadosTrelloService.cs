using Domain.Comentario;
using Domain.Entities;
using Domain.Membro;
using System.Collections.Generic;

namespace Domain.DadosTrello
{
    public class DadosTrelloService : IDadosTrelloService
    {
        IDadosQuadroDesenvRepository _dadosQuadroDesenvRepository;
        IMembroRepository _membroRepository;
        IComentarioRepository _comentariosRepository;

        public DadosTrelloService(IDadosQuadroDesenvRepository dadosQuadroDesenvRepository, IMembroRepository membroRepository, IComentarioRepository comentariosRepository)
        {
            _dadosQuadroDesenvRepository = dadosQuadroDesenvRepository;
            _membroRepository = membroRepository;
            _comentariosRepository = comentariosRepository;
        }

        public DadosCardProcessadosCs Get()
        {
            List<DadosCardCs> dadosCard = _dadosQuadroDesenvRepository.Get();
            DadosCardProcessadosCs dadosCardProcessados = new DadosCardProcessadosCs();

            int tamList = dadosCard.Count;
            double qtdHorasConcluido = 0, qtdHorasPrevisto = 0;
            for (int i=0; i< tamList; i++)
            {
                //Popula os comentários
                dadosCard[i].comentarios = _comentariosRepository.Get(dadosCard[i].Id);

                //Filtra os comentarios
                if (!dadosCard[i].comentarios.filtraComentarios())
                {
                    dadosCard.RemoveAt(i);
                    tamList--;
                    i--;
                    continue;
                }

                //Popula os membros
                for (int j = 0; j != dadosCard[i].idMembers.Length; j++)
                {
                    dadosCard[i].membros.Add(_membroRepository.Get(dadosCard[i].idMembers[j]));
                }

                //Processa os dados
                dadosCard[i].setDados();     
                
                //Verifica horas Concluidas e previstas
                if(dadosCard[i].comentarios.Nom_Fase=="Escopo")
                {
                    qtdHorasConcluido = 0;
                }
                else if (dadosCard[i].comentarios.Nom_Fase == "Levantamento")
                {
                    qtdHorasConcluido = 0.1 * dadosCard[i].comentarios.Num_Horas;
                }
                else if (dadosCard[i].comentarios.Nom_Fase == "Desenvolvimento")
                {
                    qtdHorasConcluido = 0.25 * dadosCard[i].comentarios.Num_Horas;
                }
                else if (dadosCard[i].comentarios.Nom_Fase == "Homologação")
                {
                    qtdHorasConcluido = 0.75 * dadosCard[i].comentarios.Num_Horas;
                }
                else if (dadosCard[i].comentarios.Nom_Fase == "Homologado")
                {
                    qtdHorasConcluido = dadosCard[i].comentarios.Num_Horas;
                }
                else if (dadosCard[i].comentarios.Nom_Fase == "Produção")
                {
                    qtdHorasConcluido = dadosCard[i].comentarios.Num_Horas;
                }
                else
                {
                    qtdHorasConcluido = 0;
                }
                qtdHorasPrevisto = dadosCard[i].comentarios.Num_Horas - qtdHorasConcluido;


                //Seta os Dados processados
                if (dadosCard[i].Nom_Atrasado == "Atencao")
                {
                    if (dadosCard[i].Nom_Sigla.Contains("SOL"))
                    {
                        dadosCardProcessados.atencao.sol.Add(dadosCard[i]);
                        dadosCardProcessados.atencao.qtdSol.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.atencao.qtdSol.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.atencao.qtdSol.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else if (dadosCard[i].Nom_Sigla.Contains("FIX"))
                    {
                        dadosCardProcessados.atencao.fix.Add(dadosCard[i]);
                        dadosCardProcessados.atencao.qtdFix.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.atencao.qtdFix.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.atencao.qtdFix.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else
                    {
                        dadosCardProcessados.atencao.requerimento.Add(dadosCard[i]);
                        dadosCardProcessados.atencao.qtdRequerimento.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.atencao.qtdRequerimento.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.atencao.qtdRequerimento.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                }
                else if (dadosCard[i].Nom_Atrasado == "Atrasado")
                {
                    if (dadosCard[i].Nom_Sigla.Contains("SOL"))
                    {
                        dadosCardProcessados.atrasado.sol.Add(dadosCard[i]);
                        dadosCardProcessados.atrasado.qtdSol.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.atrasado.qtdSol.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.atrasado.qtdSol.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else if (dadosCard[i].Nom_Sigla.Contains("FIX"))
                    {
                        dadosCardProcessados.atrasado.fix.Add(dadosCard[i]);
                        dadosCardProcessados.atrasado.qtdFix.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.atrasado.qtdFix.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.atrasado.qtdFix.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else
                    {
                        dadosCardProcessados.atrasado.requerimento.Add(dadosCard[i]);
                        dadosCardProcessados.atrasado.qtdRequerimento.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.atrasado.qtdRequerimento.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.atrasado.qtdRequerimento.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                }
                else if (dadosCard[i].Nom_Atrasado == "Concluido")
                {
                    if (dadosCard[i].Nom_Sigla.Contains("SOL"))
                    {
                        dadosCardProcessados.concluido.sol.Add(dadosCard[i]);
                        dadosCardProcessados.concluido.qtdSol.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.concluido.qtdSol.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.concluido.qtdSol.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else if (dadosCard[i].Nom_Sigla.Contains("FIX"))
                    {
                        dadosCardProcessados.concluido.fix.Add(dadosCard[i]);
                        dadosCardProcessados.concluido.qtdFix.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.concluido.qtdFix.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.concluido.qtdFix.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else
                    {
                        dadosCardProcessados.concluido.requerimento.Add(dadosCard[i]);
                        dadosCardProcessados.concluido.qtdRequerimento.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.concluido.qtdRequerimento.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.concluido.qtdRequerimento.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                }
                else if (dadosCard[i].Nom_Atrasado == "Previsto")
                {
                    if (dadosCard[i].Nom_Sigla.Contains("SOL"))
                    {
                        dadosCardProcessados.previsto.sol.Add(dadosCard[i]);
                        dadosCardProcessados.previsto.qtdSol.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.previsto.qtdSol.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.previsto.qtdSol.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else if (dadosCard[i].Nom_Sigla.Contains("FIX"))
                    {
                        dadosCardProcessados.previsto.fix.Add(dadosCard[i]);
                        dadosCardProcessados.previsto.qtdFix.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.previsto.qtdFix.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.previsto.qtdFix.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                    else
                    {
                        dadosCardProcessados.previsto.requerimento.Add(dadosCard[i]);
                        dadosCardProcessados.previsto.qtdRequerimento.qtdHorasTotal += dadosCard[i].comentarios.Num_Horas;
                        dadosCardProcessados.previsto.qtdRequerimento.qtdHorasConcluido += qtdHorasConcluido;
                        dadosCardProcessados.previsto.qtdRequerimento.qtdHorasPrevisto += qtdHorasPrevisto;
                    }
                }
            }

            dadosCardProcessados.previsto.qtdSol.qtdTotal = dadosCardProcessados.previsto.sol.Count;
            dadosCardProcessados.previsto.qtdRequerimento.qtdTotal = dadosCardProcessados.previsto.requerimento.Count;
            dadosCardProcessados.previsto.qtdFix.qtdTotal = dadosCardProcessados.previsto.fix.Count;

            dadosCardProcessados.atencao.qtdSol.qtdTotal = dadosCardProcessados.atencao.sol.Count;
            dadosCardProcessados.atencao.qtdRequerimento.qtdTotal = dadosCardProcessados.atencao.requerimento.Count;
            dadosCardProcessados.atencao.qtdFix.qtdTotal = dadosCardProcessados.atencao.fix.Count;

            dadosCardProcessados.atrasado.qtdSol.qtdTotal = dadosCardProcessados.atrasado.sol.Count;
            dadosCardProcessados.atrasado.qtdRequerimento.qtdTotal = dadosCardProcessados.atrasado.requerimento.Count;
            dadosCardProcessados.atrasado.qtdFix.qtdTotal = dadosCardProcessados.atrasado.fix.Count;

            dadosCardProcessados.concluido.qtdSol.qtdTotal = dadosCardProcessados.concluido.sol.Count;
            dadosCardProcessados.concluido.qtdRequerimento.qtdTotal = dadosCardProcessados.concluido.requerimento.Count;
            dadosCardProcessados.concluido.qtdFix.qtdTotal = dadosCardProcessados.concluido.fix.Count;

            return dadosCardProcessados;
        }
    }
}
