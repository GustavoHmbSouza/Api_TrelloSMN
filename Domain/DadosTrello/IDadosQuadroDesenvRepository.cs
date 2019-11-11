using Domain.Entities;
using System.Collections.Generic;

namespace Domain.DadosTrello
{
    public interface IDadosQuadroDesenvRepository
    {
        List<DadosCardCs> Get();
    }
}
