using Domain.Entities;
using System.Collections.Generic;

namespace Domain.DadosTrello
{
    public class DadosTrelloService : IDadosTrelloService
    {
        IDadosQuadroDesenvRepository _dadosQuadroDesenvRepository;

        public DadosTrelloService(IDadosQuadroDesenvRepository dadosQuadroDesenvRepository)
        {
            _dadosQuadroDesenvRepository = dadosQuadroDesenvRepository;
        }

        public List<DadosCard> Get()
        {
            List<DadosCard> dadosCard = _dadosQuadroDesenvRepository.Get();

            int tamList = dadosCard.Count;
            for (int i=0; i< tamList; i++)
            {
                dadosCard[i].setDados();
                if(!dadosCard[i].verificaData())
                {
                    dadosCard.RemoveAt(i);
                    tamList--;
                    i--;
                }
            }

            return dadosCard;
        }
    }
}
