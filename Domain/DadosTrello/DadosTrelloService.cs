﻿using Domain.Entities;
using Domain.Membro;
using System.Collections.Generic;

namespace Domain.DadosTrello
{
    public class DadosTrelloService : IDadosTrelloService
    {
        IDadosQuadroDesenvRepository _dadosQuadroDesenvRepository;
        IMembroRepository _membroRepository;

        public DadosTrelloService(IDadosQuadroDesenvRepository dadosQuadroDesenvRepository, IMembroRepository membroRepository)
        {
            _dadosQuadroDesenvRepository = dadosQuadroDesenvRepository;
            _membroRepository = membroRepository;
        }

        public DadosCardProcessadosCs Get()
        {
            List<DadosCardCs> dadosCard = _dadosQuadroDesenvRepository.Get();
            DadosCardProcessadosCs dadosCardProcessados = new DadosCardProcessadosCs();

            int tamList = dadosCard.Count;
            for (int i=0; i< tamList; i++)
            {
                dadosCard[i].setDados();
                if(!dadosCard[i].verificaData())
                {
                    dadosCard.RemoveAt(i);
                    tamList--;
                    i--;
                    continue;
                }

                for (int j = 0; j != dadosCard[i].idMembers.Length; j++)
                {
                    dadosCard[i].membros.Add(_membroRepository.Get(dadosCard[i].idMembers[j]));
                }



                if (dadosCard[i].Nom_Atrasado == "Atencao")
                {
                    if (dadosCard[i].Nom_Sigla.Contains("SOL"))
                    {
                        dadosCardProcessados.atencao.sol.Add(dadosCard[i]);
                    }
                    else if (dadosCard[i].Nom_Sigla.Contains("FIX"))
                    {
                        dadosCardProcessados.atencao.fix.Add(dadosCard[i]);
                    }
                    else
                    {
                        dadosCardProcessados.atencao.requerimento.Add(dadosCard[i]);
                    }
                }
                else if (dadosCard[i].Nom_Atrasado == "Atrasado")
                {
                    if (dadosCard[i].Nom_Sigla.Contains("SOL"))
                    {
                        dadosCardProcessados.atrasado.sol.Add(dadosCard[i]);
                    }
                    else if (dadosCard[i].Nom_Sigla.Contains("FIX"))
                    {
                        dadosCardProcessados.atrasado.fix.Add(dadosCard[i]);
                    }
                    else
                    {
                        dadosCardProcessados.atrasado.requerimento.Add(dadosCard[i]);
                    }
                }
                else if (dadosCard[i].Nom_Atrasado == "Concluido")
                {
                    if (dadosCard[i].Nom_Sigla.Contains("SOL"))
                    {
                        dadosCardProcessados.concluido.sol.Add(dadosCard[i]);
                    }
                    else if (dadosCard[i].Nom_Sigla.Contains("FIX"))
                    {
                        dadosCardProcessados.concluido.fix.Add(dadosCard[i]);
                    }
                    else
                    {
                        dadosCardProcessados.concluido.requerimento.Add(dadosCard[i]);
                    }
                }        
            }




            return dadosCardProcessados;
        }
    }
}
