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

        public IEnumerable<DadosCard> Get()
        {
            IEnumerable<DadosCard> dadosCard = _dadosQuadroDesenvRepository.Get();

            foreach (var linha in dadosCard)
            {
                linha.setDados();
            }

            return dadosCard;
        }
    }
}
