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
            return _dadosQuadroDesenvRepository.Get();
        }
    }
}
