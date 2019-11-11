using Domain.Entities;
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

        public List<DadosCardCs> Get()
        {
            List<DadosCardCs> dadosCard = _dadosQuadroDesenvRepository.Get();

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
            }

            return dadosCard;
        }
    }
}
