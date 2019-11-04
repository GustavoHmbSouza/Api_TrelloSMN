using Domain.Entities;
using System.Collections.Generic;

namespace Domain.DadosTrello
{
    public interface IDadosTrelloService
    {
        List<DadosCard> Get();
    }
}
